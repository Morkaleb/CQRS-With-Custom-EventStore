using CQRSWITHES.Infra;

namespace CQRSWITHES.src.commands
{
    // All commands must inherit from CQRSWithES.Infra.Commands  This is required for Infra.CommandHandler
    // Domain/Aggregate 
    public class ExampleCommand : Commands
    {
        //Id is inherited from Commands
        public string Name { get; set; }
        public string Email { get; set; }
    }

    // This command will then be sent by the controller via the commandHandler to the appropriate Aggregate
    // within the domain
}
