using Microsoft.IdentityModel.Tokens;

namespace SignalRDemo.Server.Application.Services;

public interface IDeclarationsLockManager
{
    bool IsLocked(string declarationId);
    bool IsLockedByOtherUser(string declarationId, string currentUserId);
    void Lock(string declarationId, string userId);
    void Unlock(string declarationId);
    void UnlockAllLockedBy(string userId);
}

public class DeclarationsLockManager : IDeclarationsLockManager
{
    private readonly ICache<List<string>> _declarationLockCache;
    private readonly object _lock = new();

    public DeclarationsLockManager(ICache<List<string>> declarationLockCache)
    {
        _declarationLockCache = declarationLockCache;
    }

    public bool IsLocked(string declarationId)
    {
        // ReSharper disable once InconsistentlySynchronizedField
        return _declarationLockCache.TryGetValue(declarationId, out var users) && !users.IsNullOrEmpty();
    }

    public bool IsLockedByOtherUser(string declarationId, string currentUserId)
    {
        // ReSharper disable once InconsistentlySynchronizedField
        return _declarationLockCache.TryGetValue(declarationId, out var users) && (!users?.Contains(currentUserId) ?? false);
    }

    public void Lock(string declarationId, string userId)
    {
        lock (_lock)
        {
            if (IsLockedByOtherUser(declarationId, userId))
            {
                throw new InvalidOperationException($"The declaration {declarationId} is already locked by another user.");
            }

            _declarationLockCache.Set(declarationId, new List<string> { userId });
        }
    }

    public void Unlock(string declarationId)
    {
        lock (_lock)
        {
            _declarationLockCache.Remove(declarationId);
        }
    }
}