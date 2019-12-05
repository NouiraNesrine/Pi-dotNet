using Data;
using Service_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public interface IRateService : IService<rate>
    {
        IEnumerable<rate> ListRateByUser(int? id);
    }
}
