using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeiss.Test.Contracts;
using Zeiss.Test.Contracts.Models;

namespace Zeiss.Test.Implementations
{
    public class DataService : IDataService
    {
        private readonly IDataStorage _dataStorage;
        public DataService(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        public List<Guid> GetAllMachineIds()
        {
            var events = _dataStorage.GetAll();
            return events.Where(e => e.Payload is MachineStatusPayload).Select(e => ((MachineStatusPayload)e.Payload).MachineId).ToList();
        }

        public MachineStatus GetMachineStatusBy(Guid machineId)
        {
            MachineStatus machineStatus = new MachineStatus();
            var machineStatusPayload = _dataStorage.GetMachineStatus(machineId);
            machineStatus.MachineId = machineStatusPayload.MachineId;
            machineStatus.Id = machineStatusPayload.Id;
            machineStatus.Date = machineStatusPayload.TimeStamp;
            machineStatus.Status = machineStatusPayload.Status;

            return machineStatus;
        }
    }
}
