 </br# CQRS-With-Custom-EventStore
An effort to build a working CQRS w/ event store onboard that stores DB as JSON

This is a template for a CQRS Patterned API.  To use, simply add event, command models, build out the domain, fill out controllers and readmodels 
and you'll have a fully operation API All of the boiler plate infastracture stuff is taken care of, as long as you are able to deploy to a server
which can host a JSON File.  NOTE, there are stll some TODO's not finished.

TODO <br/>
  //Force Synchronous writes to EVENTSTORE.Json <br/>
  //set up automation of EVENTSTORE.Json to adjust to different server environments and to build it from scratch if it's not there <br/>
  //Test Deployment on multiple Server environments. <br/>
  
 Done <br/>
  //Synchronous Application of events from EVENTSTORE.json on start is now forced, events hit the readmodels in the right order. <br/>
