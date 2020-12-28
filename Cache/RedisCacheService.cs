using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace KTSite.Cache
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<string> GetCacheValueAsync(string key)
        {
            var redis = _connectionMultiplexer.GetDatabase();
            return await redis.StringGetAsync(key);
        }

        public async Task SetCacheValueAsync(string key, string value)
        {
            var redis = _connectionMultiplexer.GetDatabase();
            await redis.StringSetAsync(key, value);
        }
    }
}
