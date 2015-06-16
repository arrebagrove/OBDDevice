using System;

namespace Mojio.Client.OBDDevice.Contracts
{
    public interface IOBDParsedResult
    {
        IMeasure Measure { get; set; }

        string Request { get; set; }

        string Raw { get; set; }

        string RequestType { get; set; }

        DateTimeOffset TimeStamp { get; set; }

        DateTimeOffset StartReceive { get; set; }

        DateTimeOffset EndReceive { get; set; }

        bool Timeout { get; set; }

        string Error { get; set; }
    }
}