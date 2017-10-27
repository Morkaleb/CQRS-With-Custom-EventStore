using CQRSWITHES.Infra;

namespace CQRSWITHES.src.events
{
    //All Events must inherit from CQRSWithES.Infra.Events in or for them to be 
    //polymorphic.  It's required by the EventWorker.

    public class ExampleEvent : Events
    {
        //This is were you model the event that you're interested in creating
        //We'll make a UserCreated Event here for an example

        
        // public string Id { get; set; } is Inherited from Events
        // Public DateTime TimeStamp { get; set;} is Inherited from Events
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
