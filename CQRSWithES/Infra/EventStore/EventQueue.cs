using CQRSWithES.Infra;
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
        }

        public static void QueuePublisher()
        {
            while(publishingQueue.Count> 0)
            {

                Debug.WriteLine("event " + publishingQueue[0].EventType + " read");
                EventDistributor.Publish(publishingQueue[0]);
                publishingQueue.RemoveAt(0);
            }
        }

        
    }
    
}
