using CQRSWITHES.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSWITHES.Infra
{
    public abstract class Aggregate
    {
        public abstract void Hydrate(EventModel evt);
        public abstract void Execute(Commands cmd);
    }
}
