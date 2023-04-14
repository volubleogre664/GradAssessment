namespace WebAPI.Services
{
    using Microsoft.Extensions.Caching.Memory;

    using WebAPI.Interfaces;
    
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache cache;

        public CacheService(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public string GetItem(string key)
        {
            return (string) this.cache.Get(key);
        }

        public void SetItem(string key, string value)
        {
            this.cache.Set(key, value, TimeSpan.FromMinutes(30));
        }
    }
}
