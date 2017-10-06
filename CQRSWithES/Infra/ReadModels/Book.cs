using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSWithES.Infra
{
    public static class Book
    {
       public static Dictionary<string, List<ReadModelData>> book = new Dictionary<string, List<ReadModelData>>();
    }
}