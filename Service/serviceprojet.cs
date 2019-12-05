
using Data;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface serviceprojet : IService<projet>
    {
        projet getByIds(int id);
    }
}
