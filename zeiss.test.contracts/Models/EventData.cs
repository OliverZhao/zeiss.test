using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiss.Test.Contracts.Models
{
    public class EventData
    {
        public string Topic { get; set; }
        public Payload Payload { get; set; }
        public EventTypeEnum EventType { get; set; }
        public object Ref { get; set; }
    }
}
