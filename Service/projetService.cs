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
    public class projetService : Service <projet>,serviceprojet
    {
        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        private static IUnitOfWork UOW = new UnitOfWork(dbfactory);
        private Context db = new Context();
        public projetService() : base(UOW)
        {
        }

        public projet getByIds(int pId)
        {
            return db.projets.Where(o => o.id == pId).SingleOrDefault();
        }
    }
}
