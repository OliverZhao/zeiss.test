using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiss.Test.Contracts;
using Zeiss.Test.Contracts.Models;

namespace Zeiss.Test.Implementations
{
    public class DbDataStorage : IDataStorage
    {
        public List<EventData> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<EventData>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public MachineStatusPayload GetMachineStatus(Guid machineId)
        {
            throw new NotImplementedException();
        }

        public void Store(IEnumerable<EventData> data)
        {
            throw new NotImplementedException();
        }

        public Task StoreAsync(IEnumerable<EventData> data, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
