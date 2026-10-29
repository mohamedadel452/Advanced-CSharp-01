using System;

namespace Advanced_CSharp_01
{
    #region CacheItem<TValue> Struct/Class
    /// <summary>
    /// Represents an internal entry inside the Cache<TKey, TValue> with TTL expiration (Q20).
    /// </summary>
    /// <typeparam name="TValue">Type of cached value.</typeparam>
    public class CacheItem<TValue>
    {
        #region Properties
        public TValue Value { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime? ExpiresAt { get; }

        public bool IsExpired => ExpiresAt.HasValue && DateTime.UtcNow >= ExpiresAt.Value;
        #endregion

        #region Constructors
        public CacheItem(TValue value, TimeSpan? duration = null)
        {
            Value = value;
            CreatedAt = DateTime.UtcNow;
            ExpiresAt = duration.HasValue ? CreatedAt.Add(duration.Value) : null;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            string expiryInfo = ExpiresAt.HasValue ? $"Expires at {ExpiresAt.Value:HH:mm:ss.fff}" : "Never expires";
            return $"[{Value}] ({expiryInfo})";
        }
        #endregion
    }
    #endregion
}
