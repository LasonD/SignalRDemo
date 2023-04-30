namespace SignalRDemo.Server.Application.Services;

public interface IDeclarationsCacheManager
{
    bool IsLocked(string declarationId);
    bool IsLockedByOtherUser(string declarationId, string currentUserId);
    void Lock(string declarationId, string userId);
    void Unlock(string declarationId);
    void UnlockAllLockedBy(string userId);
}

public class DeclarationsLockManager : IDeclarationsCacheManager
{
    private readonly ICache<string> _declarationLockCache;
    private readonly object _lock = new();

    public DeclarationsLockManager(ICache<string> declarationLockCache)
    {
        _declarationLockCache = declarationLockCache;
    }

    public bool IsLocked(string declarationId)
    {
        return _declarationLockCache.TryGetValue(declarationId, out _);
    }

    public bool IsLockedByOtherUser(string declarationId, string currentUserId)
    {
        return _declarationLockCache.TryGetValue(declarationId, out var user) && user == currentUserId;
    }

    public void Lock(string declarationId, string userId)
    {
        lock (_lock)
        {
            if (IsLockedByOtherUser(declarationId, userId))
            {
                throw new InvalidOperationException($"The declaration {declarationId} is already locked by another user.");
            }

            _declarationLockCache.Set(declarationId, userId);
        }
    }

    public void Unlock(string declarationId)
    {
        _declarationLockCache.Set(declarationId, null);
    }

    public void UnlockAllLockedBy(string userId)
    {
        _
    }
}