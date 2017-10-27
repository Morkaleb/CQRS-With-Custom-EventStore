using System;
using System.Collections.Generic;

namespace CQRSWITHES.Infra
{
    public class EventModel
    {
        public string Id { get; set; }
        public string EventType { get; set; }
        public DateTime TimeStamp { get; set; }
        public Dictionary<string, string> body = new Dictionary<string, string>();

        public void Set(string key, string value)
        {
            body.Add(key, value);
        }
        public string Get(string key, string value)
        {
            string result = null;
            if (body.ContainsKey(key))
            {
                result = body[key];
            }
            return result;
        }

    }

}
