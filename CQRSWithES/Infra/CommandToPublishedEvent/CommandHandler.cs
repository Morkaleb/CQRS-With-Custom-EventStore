using CQRSWITHES.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSWITHES.Infra
{
    public static class CommandHandler
    {
        public static  void ActivateCommand(Commands cmd, Aggregate aggregate)
        {
            var blah = EventDictionary.Streams;
            EventStream events = new EventStream();
            if (cmd != null)
            {
                if (EventDictionary.Streams.ContainsKey(cmd.Id))
                {
                    events = EventDictionary.Streams[cmd.Id];
                    foreach (var evt in events.events)
                    {
                        aggregate.Hydrate(evt);
                    }
                }
            }
            aggregate.Execute(cmd);
        }
    }
}
