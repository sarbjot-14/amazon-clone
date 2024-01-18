using StackExchange.Redis;
using System.Threading.Tasks;

namespace InventoryService.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer connectionMultiplexer;

        public RedisCacheService(IConnectionMultiplexer connectionMultiplexer)
        {
            this.connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<string> GetCacheValueAsync(string key)
        {
            var db = connectionMultiplexer.GetDatabase();
            return await db.StringGetAsync(key);

        }

        public async Task SetCacheValueAsync(string key, string value)
        {
            var db = connectionMultiplexer.GetDatabase();
            await db.StringSetAsync(key, value);
        }

        public async Task DeleteKeyAsync(string key)
        {
            var db = connectionMultiplexer.GetDatabase();
            await db.KeyDeleteAsync(key);

        }
    }
}