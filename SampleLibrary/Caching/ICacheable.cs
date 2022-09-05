using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLibrary.Caching
{
    public interface ICacheable
    {
        string CacheKey { get; }
    }
}
