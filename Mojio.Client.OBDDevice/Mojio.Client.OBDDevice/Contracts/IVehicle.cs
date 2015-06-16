namespace Mojio.Client.OBDDevice.Contracts
{
    public interface IVehicle
    {
        string Version { get; set; }

        bool Connected { get; set; }

        void Monitor();
    }
}