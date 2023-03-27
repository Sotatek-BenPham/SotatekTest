using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SotatekTest.Infrastructure.Services
{
    public class CacheService<T>: ICacheService<T> where T : class
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<IEnumerable<T>> GetData(string key)
        {
            var data = _cache.Get<string>(key);
            IEnumerable<T>? list = null;
            if (data != null)
            {
                list = JsonSerializer.Deserialize<IEnumerable<T>>(data);
            }
            return list;
        }

        public Task<string> SetData(string key, string data, MemoryCacheEntryOptions options)
        {
             return Task.FromResult(_cache.Set(key, data, options));
        }
    }
}
