using System.Collections.Concurrent;

namespace SignalRDemo.Server.Application.Services;

public interface ICache<in TKey, TValue>
{
    bool TryGetValue(TKey key, out TValue? value);
    void Set(TKey key, TValue? value);
    TValue? Remove(TKey key);
}

public class InMemoryCache<TKey, TValue> : ICache<TKey, TValue> where TKey : notnull
{
    private static readonly ConcurrentDictionary<TKey, TValue> Cache = new();

    public bool TryGetValue(TKey key, out TValue? value)
    {
        return Cache.TryGetValue(key, out value);
    }

    public void Set(TKey key, TValue? value)
    {
        Cache.AddOrUpdate(key, _ => value!, (_, _) => value!);
    }

    public TValue? Remove(TKey key)
    {
        Cache.Remove(key, out var value);
        return value;
    }
}