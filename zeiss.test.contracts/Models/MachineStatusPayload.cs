using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiss.Test.Contracts.Models
{
    public class MachineStatusPayload : Payload
    {
        public DateTime TimeStamp { get; set; }
        public MachineStatusEnum Status { get; set; }
    }
}
