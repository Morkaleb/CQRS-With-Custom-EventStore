using System.Collections.Generic;

namespace CQRSWITHES.Infra
{
    public class EventStream
    {
        public List<EventModel> events = new List<EventModel>();
        public void Set(EventModel eventToAdd)
        {
            events.Add(eventToAdd);
        }
        public EventModel Get(EventModel eventToGet)
        {
            EventModel eventGotten = null;

            if (events.Contains(eventToGet))
            {
                eventGotten = events.Find(x => x.Id == eventToGet.Id);
            }
            return eventGotten;
        }
    }

}
