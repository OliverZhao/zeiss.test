using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiss.Test.Contracts.Models;

namespace Zeiss.Test.Contracts
{
    public interface IDataService
    {
        List<Guid> GetAllMachineIds();
        MachineStatus GetMachineStatusBy(Guid machineId);
    }
}
