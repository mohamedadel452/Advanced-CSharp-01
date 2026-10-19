using System;
using System.Collections.Generic;

namespace OOP06_Generics
{
    #region Q13 & Q14: SafeList<T> Class & 'default' Keyword
    /// <summary>
    /// Demonstrates the 'default' keyword in Generics (Q13 & Q14).
    /// SafeList<T> returns default(T) when index is invalid instead of throwing ArgumentOutOfRangeException.
    /// - For Reference Types: returns null.
    /// - For Numeric Value Types: returns 0.
    /// - For Booleans: returns false.
    /// - For Structs: returns a bitwise zero-initialized instance.
    /// </summary>
    /// <typeparam name="T">Any type (value type or reference type).</typeparam>
    public class SafeList<T>
    {
        #region Fields
        private readonly List<T> _items = new List<T>();
        #endregion

        #region Properties
        public int Count => _items.Count;
        #endregion

        #region Indexers
        /// <summary>
        /// Safe Indexer: returns default(T) if the index is out of range.
        /// </summary>
        public T? this[int index]
        {
            get
            {
                if (index < 0 || index >= _items.Count)
                {
                    // Returns default value of T without throwing an exception:
                    return default;
                }
                return _items[index];
            }
            set
            {
                if (index >= 0 && index < _items.Count && value != null)
                {
                    _items[index] = value;
                }
            }
        }
        #endregion

        #region Methods
        public void Add(T item)
        {
            _items.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            _items.AddRange(items);
        }
        #endregion
    }
    #endregion
}
