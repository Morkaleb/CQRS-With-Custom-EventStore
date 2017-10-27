using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CQRSWITHES.Infra.EventStore;
using CQRSWITHES.Infra;

namespace CQRSWITHES.Infra
{
    public class ReadSaved
    {
        public static void SavedEventReader()
        {
            string path = @"./EventStore.json";
            string file = File.ReadAllText(path);
            EventDictionary.Streams = ReadSavedEvents.ReturnEventStream(file);
        }

        //private static async void AddToDictionary(EventModel convert)
        //{
        //    if (convert.Id != null)
        //    {
        //        if (EventDictionary.Streams.ContainsKey(convert.Id))
        //        {
        //            EventDictionary.Streams[convert.Id].events.Add(convert);
        //        }
        //        else
        //        {
        //            EventStream newStream = new EventStream();
        //            newStream.events.Add(convert);
        //            EventDictionary.Streams.Add(convert.Id, newStream);
        //        }
        //    }
        //}
    }

}
