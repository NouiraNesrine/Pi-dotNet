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
    class UserStatService : Service<UserMissionStats> , IUserStatService
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
        public UserStatService() : base(UOW)
        {

        }
    }
}
