using Microsoft.Extensions.Caching.Memory;

namespace AsyncFlows.Modules.Extensions;

public static class MsMemCache
{
    public static async Task<TValue> SetCacheValueAsync<TValue>(this Task<TValue> valueAsync, IMemoryCache cache, object key, TimeSpan ttl)
        => cache.Set(key, await valueAsync, ttl);

    public static async Task<TValue> SetCacheValueAsync<TValue>(this Task<TValue> valueAsync, IMemoryCache cache, object key, Func<TValue, TimeSpan> ttl)
        => (await valueAsync).SetCacheValue(cache, key, ttl);

    public static async Task<TValue> SetCacheValueAsync<TValue>(this Task<TValue> valueAsync, IMemoryCache cache, object key, Func<TValue, TimeSpan> ttl, Action expiredCallback)
        => (await valueAsync).SetCacheValue(cache, key, ttl, expiredCallback);

    public static TValue SetCacheValue<TValue>(this TValue value, IMemoryCache cache, object key, TimeSpan ttl)
        => cache.Set(key, value, ttl);

    public static TValue SetCacheValue<TValue>(this TValue value, IMemoryCache cache, object key, Func<TValue, TimeSpan> ttl)
        => cache.Set(key, value, ttl(value));

    public static TValue SetCacheValue<TValue>(this TValue value, IMemoryCache cache, object key, Func<TValue, TimeSpan> ttl, Action expiredCallback)
        => cache.Set(key, value, new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(ttl(value))
                .RegisterPostEvictionCallback((key, value, reason, state) =>
                    {
                        if (reason == EvictionReason.Expired)
                            expiredCallback();
                    }));
}
