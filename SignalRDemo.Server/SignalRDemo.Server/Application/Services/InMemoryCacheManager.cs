using System.Collections.Concurrent;

namespace SignalRDemo.Server.Application.Services;

public interface ICache<TValue>
{
    bool TryGetValue(string key, out TValue? value);
    void Set(string key, TValue? value);
    TValue? Remove(string key);
}

public class InMemoryCache<TValue> : ICache<TValue>
{
    private static readonly ConcurrentDictionary<string, TValue> Cache = new();

    public bool TryGetValue(string key, out TValue? value)
    {
        return Cache.TryGetValue(key, out value);
    }

    public void Set(string key, TValue? value)
    {
        Cache.AddOrUpdate(key, _ => value!, (_, _) => value!);
    }

    public TValue? Remove(string key)
    {
        Cache.Remove(key, out var value);
        return value;
    }
}