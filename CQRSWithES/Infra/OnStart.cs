using CQRSWITHES.Infra.EventStore;
using CQRSWITHES.Infra.EventStore;

namespace CQRSWITHES.Infra
{
    public class OnStart
    {
         public static void Start()
         {
           ReadSaved.SavedEventReader();
         }                
    }
}
