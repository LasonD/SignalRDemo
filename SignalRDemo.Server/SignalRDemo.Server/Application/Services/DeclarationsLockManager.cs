namespace SignalRDemo.Server.Application.Services;

public interface IDeclarationsLockManager
{
    bool IsLocked(string declarationId);
    bool IsLockedByOtherUser(string declarationId, string currentUserId);
    void Lock(string declarationId, string userId);
    void Unlock(string declarationId);
    IEnumerable<string> UnlockAllLockedBy(string userId);
}

public class DeclarationsLockManager : IDeclarationsLockManager
{
    private readonly ICache<string, List<string>> _userToLockedDeclarationsCache;
    private readonly ICache<string, string> _declarationToUserCache;
    private readonly object _lock = new();

    public DeclarationsLockManager(
        ICache<string, List<string>> userToLockedDeclarationsCache,
        ICache<string, string> declarationToUserCache
    )
    {
        _userToLockedDeclarationsCache = userToLockedDeclarationsCache;
        _declarationToUserCache = declarationToUserCache;
    }

    public bool IsLocked(string declarationId)
    {
        // ReSharper disable once InconsistentlySynchronizedField
        return _declarationToUserCache.TryGetValue(declarationId, out var userId) &&
               !string.IsNullOrWhiteSpace(userId);
    }

    public bool IsLockedByOtherUser(string declarationId, string currentUserId)
    {
        // ReSharper disable once InconsistentlySynchronizedField
        return _declarationToUserCache.TryGetValue(declarationId, out var userId) && 
               !string.IsNullOrWhiteSpace(userId) &&
               userId != currentUserId;
    }

    public void Lock(string declarationId, string userId)
    {
        lock (_lock)
        {
            if (IsLockedByOtherUser(declarationId, userId))
            {
                throw new InvalidOperationException($"The declaration {declarationId} is already locked by another user.");
            }

            var isInCache = _userToLockedDeclarationsCache.TryGetValue(userId, out var declarations);
            declarations ??= new List<string>();
            declarations.Add(declarationId);

            if (!isInCache)
            {
                _userToLockedDeclarationsCache.Set(userId, declarations);
            }

            _declarationToUserCache.Set(declarationId, userId);
        }
    }

    public void Unlock(string declarationId)
    {
        lock (_lock)
        {
            if (_declarationToUserCache.TryGetValue(declarationId, out var userId))
            {
                _declarationToUserCache.Remove(declarationId);
            }

            if (userId != null && _userToLockedDeclarationsCache.TryGetValue(userId, out var declarations))
            {
                declarations?.Remove(declarationId);
            }
        }
    }

    public IEnumerable<string> UnlockAllLockedBy(string userId)
    {
        lock (_lock)
        {
            if (!_userToLockedDeclarationsCache.TryGetValue(userId, out var declarations) || declarations == null)
            {
                return Array.Empty<string>();
            }

            foreach (var declaration in declarations)
            {
                _declarationToUserCache.Remove(declaration);
            }

            return declarations;
        }
    }
}