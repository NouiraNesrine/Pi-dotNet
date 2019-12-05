using Data;
using Data.Infrastructure;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ActivityService : Service<activity>, activityInterface
    {

        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        private static IUnitOfWork UOW = new UnitOfWork(dbfactory);
        private Context db = new Context();
        public ActivityService() : base(UOW)
        {
        }

        public activity getistActivityByProjet(int pId, int cId)
        {
            throw new NotImplementedException();
        }
    }
}
