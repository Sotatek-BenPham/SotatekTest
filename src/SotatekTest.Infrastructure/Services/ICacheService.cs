using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotatekTest.Infrastructure.Services
{
    public interface ICacheService<T> where T : class
    {
        public Task<IEnumerable<T>> GetData(string key);

        public Task<string> SetData(string key, string data, MemoryCacheEntryOptions options);
    }

}
