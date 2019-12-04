
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        PiContext DataContext { get; }
    }

}
