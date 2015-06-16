using Mojio.Client.OBDDevice.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client.OBDDevice
{
    public class Vehicle : IVehicle, IObservable<IOBDParsedResult>
    {
        private readonly IDeviceConnection _connection;
        private readonly IOBDParser _parser;
        private readonly IPIDListProvider _pidListProvider;

        public Vehicle(IDeviceConnection connection, IOBDParser parser, IPIDListProvider pidListProvider)
        {
            _connection = connection;
            _parser = parser;
            _pidListProvider = pidListProvider;
            Connected = false;
        }

        public bool Connected { get; set; }

        public string Version { get; set; }

        public void Monitor()
        {
            Task.Factory.StartNew(() =>
            {
                Connected = _connection.Connected;

                if (_connection.Connected)
                {
                    // Perform a reset on the ELM.  If we get a null back from this call,
                    // it means we're unable to see it (probably a wiring issue).

                    if (_connection.SendAndReceive("ATZ") == null)
                    {
                        //no connection
                    }
                    // Turn line feeds and echo off, turn on space printing (as our code currently expects it) and retrieve the ELM's version information
                    // TODO: ELM responses will be faster if we turn off space printing, but leaving
                    // as-is for now to enable easy message parsing
                    var z = _connection.SendAndReceive("ATL0");
                    var y = _connection.SendAndReceive("ATE0");
                    var x = _connection.SendAndReceive("ATS1");
                    Version = _connection.SendAndReceive("ATI").Raw;

                    var u = _connection.SendAndReceive("0100");

                    //if (response == null || response.IndexOf("41 00") != 0)
                    //    return ElmConnectionResultType.NoConnectionToObd;

                    // Ask the ELM to give us the protocol it's using.  We need to ask for
                    // this value in case the user chose the "Automatic" setting for protocol
                    // type, so we'll know which protocol was actually selected by the ELM.

                    var t = _connection.SendAndReceive("ATDPN");

                    //if (response != null && response.Length > 0)
                    //{
                    //    try
                    //    {
                    //        // 'A' will be the first character returned if the user chose
                    //        // automatic search mode

                    //        if (response[0] == 'A' && response.Length > 1)
                    //            this.protocolType = (ElmObdProtocolType)response[1];
                    //        else
                    //            this.protocolType = (ElmObdProtocolType)response[0];
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Util.Log(ex);
                    //    }
                    //}

                    while (true)
                    {
                        Connected = _connection.Connected;
                        UpdatePids();
                        //Task.Delay(100).Wait();
                    }
                }
                else
                {
                    Task.Delay(1000).Wait();
                }
            }, TaskCreationOptions.LongRunning);
        }

        private void UpdatePids()
        {
            foreach (var pid in _pidListProvider.PIDs)
            {
                UpdateMeasure(pid);
            }
        }

        private void UpdateMeasure(IPID pid)
        {
            var r = _connection.SendAndReceive(pid.PIDValue);
            r.RequestType = pid.PidName;

            if (pid.IsMeasure && pid.Enabled)
            {
                r.Measure = pid.ParseMeasure(r);

                pid.LastFailedReading = DateTimeOffset.MinValue;
                if (!string.IsNullOrEmpty(r.Error))
                {
                    pid.LastFailedReading = DateTimeOffset.UtcNow;
                }
            }

            pid.Enabled = (DateTimeOffset.UtcNow - pid.LastFailedReading).Minutes <= 5; //if we had a failure in the last 5 min, disable it

            Push(r);
        }

        private void Push(IOBDParsedResult result)
        {
            if (_observers != null)
            {
                foreach (var o in _observers)
                {
                    if (string.IsNullOrEmpty(result.Error))
                    {
                        o.OnNext(result);
                    }
                    else
                    {
                        var e = new OBDException(result.Error);
                        e.ObdParsedResult = result;
                        o.OnError(e);
                    }
                }
            }
        }

        private List<IObserver<IOBDParsedResult>> _observers = new List<IObserver<IOBDParsedResult>>();

        public IDisposable Subscribe(IObserver<IOBDParsedResult> observer)
        {
            if (!_observers.Contains(observer)) _observers.Add(observer);
            return new Unsubscriber<IOBDParsedResult>(_observers, observer);
        }
    }
}