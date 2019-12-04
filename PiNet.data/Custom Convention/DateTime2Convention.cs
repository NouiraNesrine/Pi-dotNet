using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Threading.Tasks;

namespace data.Custom_Convention
{
    class DateTime2Convention : Convention
    {
        public DateTime2Convention()
        {
            Properties<DateTime>().Configure(x => x.HasColumnType("DateTime2"));
        }
    }
}
