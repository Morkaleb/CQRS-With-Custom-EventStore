using CQRSWithES.src.ReadModels;
using CQRSWithES.Infra;
using CQRSWithES.Infra.EventStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CQRSWithES.Infra.ReadModels;

namespace CQRSWithES.Infra
{
    public static class EventDistributor
    {
        public static void Publish(EventModel anEvent)
        {
            var data = EventDictionary.Streams;
            string nspace = "CQRSWithES.src.ReadModels";
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == nspace
                    select t;
           
            foreach (var readModel in q)
            {
                try
                {
                    MethodInfo theMethod = typeof(ReadModels.ReadModel).GetMethod("EventPublish", new[] { typeof(EventModel) } );
                    string methodName = readModel.Name.ToString();
                    string nameSpace = readModel.Namespace.ToString();
                    string key = methodName.Split("Read")[0];
                    if (Book.book.ContainsKey(key))
                    {
                        string fullClassName = nameSpace + "." + methodName;
                        object readModelToInvoke = Activator.CreateInstance(Type.GetType(fullClassName));
                        theMethod.Invoke(readModelToInvoke, new EventModel[] { anEvent });
                    }
                    else
                    {
                        Book.book.Add(key, new List<ReadModelData>());
                        string fullClassName = nameSpace + "." + methodName;
                        object readModelToInvoke = Activator.CreateInstance(Type.GetType(fullClassName));
                        theMethod.Invoke(readModelToInvoke, new EventModel[] { anEvent });
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e);
                }

            }
        }
        
    }
}
