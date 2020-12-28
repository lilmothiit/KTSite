using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KTSite.Models.Interfaces
{
    public interface ITabHandler
    {
        IEnumerable<Tab> Tabs { get; }
    }
}
