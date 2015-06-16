namespace Mojio.Client.OBDDevice.Contracts
{
    public interface IOBDParser
    {
        IOBDParsedResult Parse(byte packget);
    }
}