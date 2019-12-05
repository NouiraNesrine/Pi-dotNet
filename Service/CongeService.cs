

using Data;
using Data.Infrastructure;
using Data.Infrastruture;
using Service_Pattern;


namespace Service
{
    public class CongeService : Service<conge>, ICongeService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
        public CongeService() : base(UOW)
        {

        }
     

    }
}
