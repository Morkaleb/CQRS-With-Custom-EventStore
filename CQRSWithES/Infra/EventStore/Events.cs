using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSWITHES.Infra
{
    public abstract class Events
    {
        public string EventType { get; set; }
        public string Id { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
