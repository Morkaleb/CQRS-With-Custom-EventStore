using CQRSWITHES.Infra.EventStore;

namespace CQRSWithES.Infra
{
    public static class OnStart
    {
         public static void Start()
         {
           ReadSaved.SavedEventReader();
           EventQueue.QueuePublisher(); 
         }        
    }
}
