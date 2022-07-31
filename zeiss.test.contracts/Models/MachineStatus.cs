using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiss.Test.Contracts.Models
{
    public class MachineStatus
    {
        public DateTime Date { get; set; }
        public MachineStatusEnum Status { get; set; }
        public Guid MachineId { get; set; }
        public Guid Id { get; set; }
    }
}
