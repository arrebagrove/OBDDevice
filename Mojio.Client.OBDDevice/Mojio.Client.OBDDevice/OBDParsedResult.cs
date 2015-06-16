using Mojio.Client.OBDDevice.Contracts;
using System;

namespace Mojio.Client.OBDDevice
{
    public class OBDParsedResult : IOBDParsedResult
    {
        public OBDParsedResult()
        {
            TimeStamp = DateTimeOffset.UtcNow;
        }

        public int Mode { get; set; }

        public int Command { get; set; }

        public object Value { get; set; }

        public string Name { get; set; }

        public IMeasure Measure { get; set; }

        public string Request { get; set; }

        public string Raw { get; set; }

        public string RequestType { get; set; }

        public DateTimeOffset TimeStamp { get; set; }

        public DateTimeOffset StartReceive { get; set; }

        public DateTimeOffset EndReceive { get; set; }

        public bool Timeout { get; set; }

        public string Error { get; set; }
    }
}