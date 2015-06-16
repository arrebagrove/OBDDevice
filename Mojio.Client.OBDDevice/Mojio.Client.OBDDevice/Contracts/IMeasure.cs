using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client.OBDDevice.Contracts
{
    public interface IMeasure
    {
        IPID PID { get; set; }

        string Name { get; set; }

        double? Value { get; set; }

        DateTimeOffset TimeStamp { get; set; }
    }
}