using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSWithES.Infra.EventStore
{
    public class Write
    {
        public static void WriteEventToFile(EventModel evt)
        {
            string path = @"./Infra/EventStore/EventStore.Json";
            var file = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<EventModel>>(file);
            list.Add(evt);
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, convertedJson);
        }

        public static void WriteToEventStore(EventModel anEvent)
        {
            var data = EventDictionary.Streams;
            if (data.ContainsKey(anEvent.Id))
            {
                data[anEvent.Id].events.Add(anEvent);
            }
            else
            {
                EventStream newStream = new EventStream();
                newStream.events.Add(anEvent);
                data.Add(anEvent.Id, newStream);
            }
            EventDictionary.Streams = data;
        }
    }
}
