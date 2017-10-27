using CQRSWITHES.Infra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSWITHES.Infra.EventStore
{
    public static class EventQueue
    {
        public static List<EventModel> publishingQueue = new List<EventModel>();

        public static void Queue(EventModel theEvent)
        {
            publishingQueue.Add(theEvent);
            while (publishingQueue.Count > 0)
            {
                EventDistributor.Publish(publishingQueue[0]);
                if (publishingQueue.Count > 0) { publishingQueue.RemoveAt(0); }
            }
        }
        
    }
    
}
