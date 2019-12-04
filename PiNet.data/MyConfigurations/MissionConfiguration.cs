using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiNet.domain.Entities;

namespace data.MyConfigurations
{
    class MissionConfiguration : EntityTypeConfiguration<Mission>
    {
        public MissionConfiguration()
        {
           
        }
    }
}
