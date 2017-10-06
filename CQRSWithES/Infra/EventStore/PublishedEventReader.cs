using CQRSWithES.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CQRSWithES.Infra
{
    public static class EventQueue
    {
        public static void Queue()
        {
            var theStream = EventDictionary.Streams;
            foreach(var stream in theStream)
            {
                foreach(EventModel anEvent in stream.Value.events)
                {
                    EventDistributor.Publish(anEvent);
                }                
            }
        }
        
    }
    
}
