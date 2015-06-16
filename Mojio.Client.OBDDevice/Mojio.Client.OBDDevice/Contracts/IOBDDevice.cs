using System;

namespace Mojio.Client.OBDDevice.Contracts
{
    public interface IOBDDevice : IObservable<IDeviceConnection>

    {
        void StartDiscovery(string deviceName);

        IDeviceConnection ConnectAsync(IDeviceConnection connection);
    }
}