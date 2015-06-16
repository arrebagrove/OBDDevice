using InTheHand;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using Mojio.Client.OBDDevice.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client.OBDDevice.InTheHandBluetooth
{
    public class BluetoothDevice : IOBDDevice
    {
        public BluetoothDevice()
        {
        }

        public void Send(byte[] data)
        {
            throw new NotImplementedException();
        }

        public IOBDParsedResult Receive()
        {
            throw new NotImplementedException();
        }

        public void StartDiscovery(string deviceName)
        {
            Console.WriteLine("Starting Discovery");
            var client = new BluetoothClient();
            BluetoothDeviceInfo[] availableDevices = client.DiscoverDevices(); // I've found this to be SLOW!

            foreach (BluetoothDeviceInfo device in availableDevices)
            {
                if (!device.Authenticated)
                {
                    continue;
                }
                if (device.DeviceName == deviceName)
                {
                    var peerClient = new BluetoothClient();
                    peerClient.BeginConnect(device.DeviceAddress, BluetoothService.SerialPort, RequestCallback, peerClient);
                }
            }
        }

        private void RequestCallback(IAsyncResult ar)
        {
            var client = ar.AsyncState as BluetoothClient;

            var deviceConnection = new DeviceConnection();
            deviceConnection.Client = client;
            if (_observers != null)
            {
                foreach (var o in _observers)
                {
                    o.OnNext(deviceConnection);
                }
            }
        }

        public IDeviceConnection ConnectAsync(IDeviceConnection connection)
        {
            throw new NotImplementedException();
        }

        private List<IObserver<IDeviceConnection>> _observers = new List<IObserver<IDeviceConnection>>();

        public IDisposable Subscribe(IObserver<IDeviceConnection> observer)
        {
            if (!_observers.Contains(observer)) _observers.Add(observer);
            return new Unsubscriber<IDeviceConnection>(_observers, observer);
        }
    }
}