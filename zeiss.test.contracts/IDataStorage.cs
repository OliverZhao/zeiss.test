using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiss.Test.Contracts.Models;

namespace Zeiss.Test.Contracts
{
    public interface IDataStorage
    {
        void Store(IEnumerable<EventData> data);
        Task StoreAsync(IEnumerable<EventData> data, CancellationToken cancellationToken);
        List<EventData> GetAll();
        Task<List<EventData>> GetAllAsync(CancellationToken cancellationToken);
        MachineStatusPayload GetMachineStatus(Guid machineId);
    }
}
