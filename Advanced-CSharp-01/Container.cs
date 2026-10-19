using System;
using System.Collections.Generic;

namespace OOP06_Generics
{
    #region Container<T> Class
    /// <summary>
    /// Generic Container class demonstrating single type parameter usage (Q2).
    /// Eliminates boxing/unboxing overhead and provides compile-time type safety.
    /// </summary>
    /// <typeparam name="T">The type of elements stored in the container.</typeparam>
    public class Container<T>
    {
        #region Fields
        private readonly List<T> _items;
        #endregion

        #region Properties
        public int Count => _items.Count;
        #endregion

        #region Constructors
        public Container()
        {
            _items = new List<T>();
        }

        public Container(int capacity)
        {
            _items = new List<T>(capacity);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds a strongly typed element of type T to the container.
        /// </summary>
        public void Add(T item)
        {
            _items.Add(item);
        }

        /// <summary>
        /// Retrieves an item at the specified zero-based index.
        /// </summary>
        public T Get(int index)
        {
            if (index < 0 || index >= _items.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} is out of range. Current count is {_items.Count}.");
            }
            return _items[index];
        }

        /// <summary>
        /// Clears all elements from the container.
        /// </summary>
        public void Clear()
        {
            _items.Clear();
        }
        #endregion
    }
    #endregion
}
