using CQRSWithES.Infra;
using CQRSWithES.Infra.ReadModels;

namespace CQRSWithES.src.ReadModels
{
    public class ExampleReadModel : ReadModel
    {
        public override void EventPublish( EventModel anEvent)
        {
            var readModelCollection = Book.book;
            switch (anEvent.EventType)
            {
                case "ExampleEvent":
                    exampleData example = new exampleData
                    {
                        Id = anEvent.Id,
                        // before the event is saved to file, or published, it is "normalized" in order to make it's fields fit into Event models.  
                        // this means all information put into the model in the src.domain folder lives inside a Dictionary
                        Name = anEvent.body["Name"],
                        Email = anEvent.body["Email"]
                    };
                    // the readModelCollection is a dictionary with is Keyed to the words in it before the "ReadModel"  When building a new readModel, be
                    // aware that case is important and everything after the word "Read" will be ignored.  
                    readModelCollection["Example"].Add(example);
                    break;                
            }
            Book.book = readModelCollection;
        }
    }
    // Here is the model for the data that we want to include in this readmodel.  We can add to this when we decide that we 
    // care about more information than we cared about before.
        public class exampleData : ReadModelData
        {
            public string Name { get; set; }
            public string Email { get; set; }           
        }
}
