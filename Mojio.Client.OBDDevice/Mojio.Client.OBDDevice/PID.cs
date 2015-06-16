using Mojio.Client.OBDDevice.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client.OBDDevice
{
    public class PID : IPID
    {
        public IMeasure ParseMeasure(IOBDParsedResult result)
        {
            var measure = new Measure();
            measure.Name = this.PidName;
            measure.PID = this;
            if (!string.IsNullOrEmpty(result.Raw))
            {
                if (result.RequestType == "Rpm")
                {
                    var data1 = (double?)Convert.ToInt32(result.Raw.Split(' ')[2], 16);
                    var data2 = (double?)Convert.ToInt32(result.Raw.Split(' ')[3], 16);
                    measure.Value = (int?)((data1 * 256) + data2) / 4;
                }
                else if (result.RequestType == "Battery")
                {
                    var raw = result.Raw;
                    if (!string.IsNullOrEmpty(raw) && raw.EndsWith("V"))
                    {
                        raw = raw.Substring(0, raw.Length - 1);
                        measure.Value = Convert.ToDouble(raw);
                    }
                }
                else
                {
                    measure.Value = (double?)Convert.ToInt32(result.Raw.Split(' ')[2], 16);
                }
            }
            result.Measure = measure;
            return measure;
        }

        public bool IsMeasure { get; set; }

        public string PIDValue { get; set; }

        public string PidName { get; set; }

        public bool Enabled { get; set; }
    }
}