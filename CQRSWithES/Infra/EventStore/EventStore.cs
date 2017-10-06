using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSWithES.Infra.EventStore
{
    public class EventStore
    {
        public static void Store(EventModel anEvent)
        {
            Write.WriteEventToFile(anEvent);
            Write.WriteToEventStore(anEvent);
        }        
    }
}
