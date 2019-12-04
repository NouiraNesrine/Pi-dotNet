using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiNet.domain.Entities;
using PiNet.servicePattern;
using data.Infrastructure;

namespace PiNet.service
{
    public class TrspExpService : Service<TransportExpenses>, ITrspExpService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
        public TrspExpService() : base(UOW)
        {

        }
    }
}
