using Mojio.Client.OBDDevice.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client.OBDDevice
{
    public class OBDException : System.Exception
    {
        public OBDException(string message) : base(message)
        {
        }

        public IOBDParsedResult ObdParsedResult { get; set; }
    }
}