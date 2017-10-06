using MenuAPI.src.events;
using MenuAPI.Infra;
using Newtonsoft;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
 

namespace MenuAPI.Infra
{
    public class EventHandler
    {
        public static void Ship(Events evt)
        {
            EventModel normalizedEvent = normalizeEvent(evt);
            EventHandler.Publish(normalizedEvent);
        }
        
        private static EventModel normalizeEvent(Events evt)
        {
            EventModel publishableEvent = new EventModel
            {
                Id = evt.Id,
                EventType = evt.GetType().ToString().Split('.').Last(),
            };
            Type typedEvent = evt.GetType();
            foreach (PropertyInfo propertyInfo in typedEvent.GetProperties())
            {
                var value = getValues(evt, propertyInfo.Name).ToString();
                publishableEvent.body.Add(propertyInfo.Name, value);
            }
            return publishableEvent;
        }       

        private static object getValues(object anEvent, string name)
        {
            return anEvent.GetType().GetProperties()
                .Single(pi => pi.Name == name)
                .GetValue(anEvent, null);
        }        
    }
}
