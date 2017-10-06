using CQRSWithES.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSWithES.Infra
{
    public class EventDictionary
    {
        public static Dictionary<string, EventStream> Streams = new Dictionary<string, EventStream>();
    }
}
