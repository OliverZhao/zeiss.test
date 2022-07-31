using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiss.Test.Contracts.Models
{
    public abstract class Payload
    {
        public Guid MachineId { get; set; }
        public Guid Id { get; set; }
    }
}
