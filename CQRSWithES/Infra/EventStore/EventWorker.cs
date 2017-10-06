using System;
using System.Linq;
using System.Reflection;


namespace CQRSWithES.Infra.EventStore
{
    public class EventWorker
    {
        public static void Work(Events evt)
        {
            evt.TimeStamp = DateTime.Now;
            EventModel normalizedEvent = normalizeEvent(evt);
            EventStore.Store(normalizedEvent);
            EventDistributor.Publish(normalizedEvent);
        }

        private static EventModel normalizeEvent(Events evt)
        {
            EventModel publishableEvent = new EventModel
            {
                Id = evt.Id,
                EventType = evt.GetType().ToString().Split('.').Last(),
                TimeStamp = DateTime.Now
            };
            Type typedEvent = evt.GetType();
            foreach (PropertyInfo propertyInfo in typedEvent.GetProperties())
            {
                if (propertyInfo.Name.ToString() != "Id" && 
                    propertyInfo.Name.ToString() != "TimeStamp" &&
                    propertyInfo.Name.ToString() != "EventType")
                {
                    var value = getValues(evt, propertyInfo.Name).ToString();
                    publishableEvent.body.Add(propertyInfo.Name, value);
                }
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
