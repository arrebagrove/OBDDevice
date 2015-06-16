using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client.OBDDevice.Contracts
{
    public interface IPID
    {
        IMeasure ParseMeasure(IOBDParsedResult result);

        DateTimeOffset LastFailedReading { get; set; }

        bool IsMeasure { get; set; }

        string PIDValue { get; set; }

        string PidName { get; set; }

        bool Enabled { get; set; }
    }
}