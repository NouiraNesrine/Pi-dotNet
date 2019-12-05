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
   public class ESHService : Service<evaluationsheet> , IESHService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);

        public ESHService() : base(UOW)
        {
        }

        public IEnumerable<evaluationsheet> GetESHById(int? id)
        {
            var res = from evaluationsheet in
               GetAll()
                      where (evaluationsheet.user.idUser == id)
                      select evaluationsheet;
            return res;
        }

    }
}
