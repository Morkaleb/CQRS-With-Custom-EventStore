using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSWITHES.Infra.EventStore
{
    public class EventStore
    {
        public static void Store(EventModel anEvent)
        {
            Write.FileWriter(anEvent);
            Write.WriteToEventStore(anEvent);
        }        
    }
}
