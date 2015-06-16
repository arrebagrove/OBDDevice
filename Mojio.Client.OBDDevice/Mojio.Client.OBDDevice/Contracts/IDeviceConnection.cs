using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client.OBDDevice.Contracts
{
    public interface IDeviceConnection
    {
        IOBDParsedResult SendAndReceive(string message);

        bool Connected { get; set; }
    }
}