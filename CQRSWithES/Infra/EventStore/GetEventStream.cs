using CQRSWITHES.Infra.EventStore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CQRSWITHES.Infra.EventStore
{
    public static class ReadSavedEvents
    {
        public static Dictionary<string, EventStream> EventDictionary = new Dictionary<string, EventStream>();

        public static Dictionary<string, EventStream> ReturnEventStream(string source)
        {
            var list = JsonConvert.DeserializeObject<List<EventModel>>(source);
            if (list.Count > 1)
            {
                foreach (var eventToFile in list)
                {
                    if (eventToFile.Id != null) { FileEvent(eventToFile); }
                }
            }
            return EventDictionary;
        }

        public static void FileEvent(EventModel eventToFile)
        {
            if (EventDictionary.ContainsKey(eventToFile.Id))
            {
                EventDictionary[eventToFile.Id].events.Add(eventToFile);
            }
            else
            {
                EventStream newStream = new EventStream();
                newStream.events.Add(eventToFile);
                EventDictionary.Add(eventToFile.Id, newStream);
            }
            EventQueue.Queue(eventToFile);
        }
    }
   
}
