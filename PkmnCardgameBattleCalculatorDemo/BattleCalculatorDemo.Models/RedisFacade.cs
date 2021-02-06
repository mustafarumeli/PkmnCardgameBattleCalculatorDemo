using System;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Newtonsoft.Json;

namespace BattleCalculatorDemo.Models
{
    public class RedisFacade
    {
        private static IDistributedCache _distributedCache = new RedisCache(new RedisCacheOptions()
        {
            Configuration = "127.0.0.1:16379"
        });

        private static readonly DistributedCacheEntryOptions _options = new DistributedCacheEntryOptions()
        {
            AbsoluteExpiration = DateTimeOffset.Now.AddDays(1),
        };

        public static void SetAsJson<T>(string key, T val)
        {
            _distributedCache.SetString(key, JsonConvert.SerializeObject(val), _options);
        }

        public static T GetFromJson<T>(string key)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(_distributedCache.GetString(key));
            }
            catch
            {
                return default(T);
            }
        }
    }
}