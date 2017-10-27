using CQRSWITHES.Infra;
using CQRSWITHES.Infra.EventStore;
using CQRSWITHES.src.commands;
using CQRSWITHES.src.events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSWITHES.src.domain
{
    public class ExampleAggregate : Aggregate
    {
        string _Id;
        string _Email;
        // Consider this as the Aggregate command Handler.  All commands enter this part of the
        // domain through the Execute function.  This ensures that there is only ever one route for 
        // data to enter an aggregate.  Making it more expandable and maintanable.
        public override void Execute(Commands cmd)
        {
            if (cmd is ExampleCommand) { _onExampleCommand((ExampleCommand)cmd); };
        }
        
        // When firing a new command, if an event with an associated Id has already been published, 
        // This "eventHandler" sends the event to the proper hydrate method, with all of the data 
        // being applied to aggregate fields that need it.
        public override void Hydrate(EventModel evt)
        {
            if(evt.EventType == "ExampleEvent") { _onExampleEvent(evt); }
        }

        // This is where the aggregate gets "hydrated" with the data contained in the event in order
        // to assure the command can be validated and relates to previous data.
        private void _onExampleEvent(EventModel evt)
        {
            _Id = evt.Id;
            // The information Defined in the ExampleEvent model will be changed to a dictionary which lives in the evt.body.
            // This could be used to define something that a future event might care about.  
            // I selected "Email" just to show the required syntax
            _Email = evt.body["Email"];
        }

        private void _onExampleCommand(ExampleCommand cmd)
        {
            // this checks the aggregate to see if a user with this Id has already been created
            if(_Id != null) { throw new ArgumentException("Id", "User already created"); }
            // here is where we can ensure that the command has all the information in it that we expect it to have
            if(cmd.Id == null) { throw new ArgumentException("Id", "Id is a required field"); }
            if(cmd.Email == null) { throw new ArgumentException("Email", "Email is a required field"); }
            if (cmd.Name == null) { throw new ArgumentException("Name", "Name is a required field"); }
            // now we assign values to the event model that we created in ExampleEvent
            Thread.Sleep(100);
            ExampleEvent exampleEvent = new ExampleEvent
            {
                Id = cmd.Id,
                Name = cmd.Name,
                Email = cmd.Email
            };
            // And finally we send the example event off to the Event Worker to be saved, filed and published
            EventWorker.Work(exampleEvent);
        }

    }
}
