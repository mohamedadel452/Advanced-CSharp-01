using System;
using System.Collections.Generic;

namespace Advanced_CSharp_01
{
    #region Q20: Generic Cache<TKey, TValue>
    /// <summary>
    /// Complete Generic In-Memory Cache with Expiration (TTL) support (Q20).
    /// Enforces TKey : notnull for safe dictionary hashing.
    /// Thread-safe via internal synchronization lock.
    /// </summary>
    /// <typeparam name="TKey">Type of cache keys (must be notnull).</typeparam>
    /// <typeparam name="TValue">Type of cached values.</typeparam>
    public class Cache<TKey, TValue> where TKey : notnull
    {
        #region Fields
        private readonly Dictionary<TKey, CacheItem<TValue>> _store = new Dictionary<TKey, CacheItem<TValue>>();
        private readonly object _syncLock = new object();
        #endregion

        #region Properties
        /// <summary>
        /// Returns the count of valid (non-expired) items in cache.
        /// </summary>
        public int Count
        {
            get
            {
                lock (_syncLock)
                {
                    PurgeExpiredInternal();
                    return _store.Count;
                }
            }
        }
        #endregion

        #region Methods: Add
        /// <summary>
        /// Adds or updates an item in the cache with an optional time-to-live (TTL).
        /// </summary>
        public void Add(TKey key, TValue value, TimeSpan? expiration = null)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            lock (_syncLock)
            {
                _store[key] = new CacheItem<TValue>(value, expiration);
            }
        }
        #endregion

        #region Methods: Get & TryGet
        /// <summary>
        /// Retrieves an item from cache. Throws KeyNotFoundException if expired or missing.
        /// </summary>
        public TValue Get(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            lock (_syncLock)
            {
                if (_store.TryGetValue(key, out var item))
                {
                    if (!item.IsExpired)
                    {
                        return item.Value;
                    }

                    // Expired: remove and throw
                    _store.Remove(key);
                }

                throw new KeyNotFoundException($"Key '{key}' was not found or has expired from the cache.");
            }
        }

        /// <summary>
        /// Attempts to retrieve an item safely without throwing an exception.
        /// </summary>
        public bool TryGet(TKey key, out TValue? value)
        {
            if (key == null)
            {
                value = default;
                return false;
            }

            lock (_syncLock)
            {
                if (_store.TryGetValue(key, out var item))
                {
                    if (!item.IsExpired)
                    {
                        value = item.Value;
                        return true;
                    }

                    // Expired: lazy eviction
                    _store.Remove(key);
                }

                value = default;
                return false;
            }
        }
        #endregion

        #region Methods: Remove & Contains
        /// <summary>
        /// Removes a key from the cache. Returns true if removed.
        /// </summary>
        public bool Remove(TKey key)
        {
            if (key == null) return false;

            lock (_syncLock)
            {
                return _store.Remove(key);
            }
        }

        /// <summary>
        /// Checks if a valid, non-expired key exists in the cache.
        /// </summary>
        public bool Contains(TKey key)
        {
            if (key == null) return false;

            lock (_syncLock)
            {
                if (_store.TryGetValue(key, out var item))
                {
                    if (!item.IsExpired) return true;

                    // Expired: purge immediately
                    _store.Remove(key);
                }
                return false;
            }
        }
        #endregion

        #region Methods: Expiration & Purging
        /// <summary>
        /// Explicitly removes all expired items from memory (active eviction).
        /// </summary>
        public int PurgeExpired()
        {
            lock (_syncLock)
            {
                return PurgeExpiredInternal();
            }
        }

        private int PurgeExpiredInternal()
        {
            var expiredKeys = new List<TKey>();
            foreach (var kvp in _store)
            {
                if (kvp.Value.IsExpired)
                {
                    expiredKeys.Add(kvp.Key);
                }
            }

            foreach (var key in expiredKeys)
            {
                _store.Remove(key);
            }

            return expiredKeys.Count;
        }

        /// <summary>
        /// Clears all entries from the cache.
        /// </summary>
        public void Clear()
        {
            lock (_syncLock)
            {
                _store.Clear();
            }
        }
        #endregion
    }
    #endregion
}
