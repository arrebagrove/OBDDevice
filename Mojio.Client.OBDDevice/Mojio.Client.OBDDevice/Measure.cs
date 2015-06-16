using Mojio.Client.OBDDevice.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client.OBDDevice
{
    public class Measure : IMeasure
    {
        public Measure()
        {
            TimeStamp = DateTimeOffset.UtcNow;
        }

        public IPID PID { get; set; }

        public string Name { get; set; }

        public double? Value { get; set; }

        public DateTimeOffset TimeStamp { get; set; }
    }
}