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

        static List<EventModel> EventQueue = new List<EventModel>();

        public static void WriteEventToFile(EventModel evt)
        {
            if(EventQueue.Count > 0)
            {
                EventQueue.Add(evt);
            }           
            while(EventQueue.Count > 0)
            {
                FileWriter(EventQueue[0]);
                EventQueue.RemoveAt(0);
            }
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

        public static void FileWriter(EventModel evt)
        {
            Task task = new Task(() =>
            {
                string path = @"./Infra/EventStore/EventStore.Json";
                var file = File.ReadAllText(path);
                var list = JsonConvert.DeserializeObject<List<EventModel>>(file);
                list.Add(evt);
                var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(path, convertedJson);
            });
            task.RunSynchronously();
        }
    }
}
