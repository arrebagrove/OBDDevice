namespace Mojio.Client.OBDDevice.Contracts
{
    public interface IVehicle
    {
        string Version { get; set; }

        void Monitor();
    }
}