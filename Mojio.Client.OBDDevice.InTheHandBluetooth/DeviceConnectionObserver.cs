using Mojio.Client.OBDDevice.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client.OBDDevice.InTheHandBluetooth
{
    public class DeviceConnectionObserver : IObserver<IDeviceConnection>, IObservable<IOBDParsedResult>, IObserver<IOBDParsedResult>
    {
        public IVehicle Vehicle { get { return _currentVehicle; } }

        private Vehicle _currentVehicle;

        public void OnNext(IDeviceConnection value)
        {
            if (value != null && _currentVehicle == null)
            {
                _currentVehicle = new Vehicle(value, new OBDParser(), new PIDListProvider());
                _currentVehicle.Subscribe(this);
                _currentVehicle.Monitor();
            }
        }

        public void OnNext(IOBDParsedResult value)
        {
            foreach (var o in _observers)
            {
                o.OnNext(value);
            }
        }

        public void OnError(Exception error)
        {
            foreach (var o in _observers)
            {
                o.OnError(error);
            }
        }

        public void OnCompleted()
        {
            foreach (var o in _observers)
            {
                o.OnCompleted();
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