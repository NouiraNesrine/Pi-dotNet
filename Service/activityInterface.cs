using Data;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public interface activityInterface : IService<activity>
    {
        //public Order getByIds(int pId, int cId, DateTime date);
       activity getistActivityByProjet(int pId, int cId);
    }
}
