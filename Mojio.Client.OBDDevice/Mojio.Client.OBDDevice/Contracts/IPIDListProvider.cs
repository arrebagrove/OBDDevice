using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client.OBDDevice.Contracts
{
    public interface IPIDListProvider
    {
        List<IPID> PIDs { get; set; }
    }
}