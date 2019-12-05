using Data;
using Data.Infrastructure;
using Data.Infrastruture;
using Service_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public class RateService : Service<rate> , IRateService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);

        public RateService() : base(UOW)
        {
        }

        public IEnumerable<rate> ListRateByUser(int? id)
        {
            var res = from rate in
               GetAll()
                      where (rate.user_idUser == id )
                      select rate;
            return res;
        }
    }
}
