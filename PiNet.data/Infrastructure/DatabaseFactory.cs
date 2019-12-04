using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private PiContext dataContext;
        public PiContext DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new PiContext();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
