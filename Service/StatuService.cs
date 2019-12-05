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
    public class StatuService : Service<statu>, IStatuService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
        public StatuService() : base(UOW)
        {

        }
    }
}
