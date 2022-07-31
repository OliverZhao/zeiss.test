using Microsoft.AspNetCore.Mvc;
using Zeiss.Test.Contracts;

namespace Zeiss.Test.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZeissTestController : ControllerBase
    {
        private readonly ILogger<ZeissTestController> _logger;
        private readonly IDataService _dataService;

        public ZeissTestController(
            IDataService dataService,
            ILogger<ZeissTestController> logger)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpGet(Name = "GetAllMachines")]
        public IEnumerable<Guid> GetAll()
        {
            return _dataService.GetAllMachineIds();
        }

        [HttpGet(Name = "GetMachine")]
        public MachineStatus Get(Guid machineId)
        {
            var status = _dataService.GetMachineStatusBy(machineId);
            return new MachineStatus
            {
                Status = status.Status.ToString(),
                Date = status.Date,
                MachineId = machineId,
                Id = status.Id
            };
        }
    }
}