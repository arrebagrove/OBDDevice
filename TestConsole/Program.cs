using Mojio.Client.OBDDevice;
using Mojio.Client.OBDDevice.Contracts;
using Mojio.Client.OBDDevice.InTheHandBluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IOBDDevice bt = new BluetoothDevice();
            var observer = new DeviceConnectionObserver();
            observer.Subscribe(new ConsoleObserver());
            bt.Subscribe(observer);
            bt.StartDiscovery("OBDII");

            while (observer.Vehicle == null)
            {
                Console.WriteLine("Waiting for Bluetooth connection to telematic device");
                Task.Delay(1000).Wait();
            }
            Console.WriteLine("Got a connection to the bluetooth telematic device");
            while (!observer.Connected)
            {
                Console.WriteLine("Waiting for Vehicle OBD Connectivity");
                Task.Delay(1000).Wait();
            }
            Console.WriteLine("Connected to the Vehicle OBD Port");
            Console.ReadKey();
        }
    }

    public class ConsoleObserver : IObserver<IOBDParsedResult>
    {
        public ConsoleObserver()
        {
            System.Console.ForegroundColor = ConsoleColor.White;
        }

        private static object _lock = new object();

        public void OnNext(IOBDParsedResult value)
        {
            lock (_lock)
            {
                if (value.Measure != null)
                {
                    System.Console.WriteLine("{0} - {1} = {2}", value.Measure.TimeStamp, value.Measure.Name, value.Measure.Value);
                }
                else
                {
                    System.Console.WriteLine("{2} : {1}, {0}", value.Raw.Replace(@"\r", "").Replace(@"\n", ""),
                        value.Request, value.RequestType);
                }
            }
        }

        public void OnError(Exception error)
        {
            lock (_lock)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                var value = (error as OBDException).ObdParsedResult;
                System.Console.WriteLine("ERROR: {2} : {1}, {0}", value.Error, value.Request, value.RequestType);
                System.Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void OnCompleted()
        {
        }
    }
}