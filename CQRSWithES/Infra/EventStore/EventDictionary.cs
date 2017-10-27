using CQRSWITHES.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSWITHES.Infra
{
    public class EventDictionary
    {
        public static Dictionary<string, EventStream> Streams = new Dictionary<string, EventStream>();
    }
}
