using System;
using System.Collections.Generic;

namespace OOP06_Generics
{
    #region Supporting Interface
    public interface IPrintable
    {
        void PrintDetails();
    }
    #endregion

    #region Q10: Interface Constraint
    /// <summary>
    /// Demonstrates 'where T : IPrintable' constraint (Q10).
    /// Ensures that any type T implements the specified interface,
    /// enabling direct calls to interface methods without casting or boxing.
    /// </summary>
    public class ReportPrinter<T> where T : IPrintable
    {
        #region Fields
        private readonly List<T> _items = new List<T>();
        #endregion

        #region Methods
        public void Add(T item)
        {
            _items.Add(item);
        }

        public void PrintAll()
        {
            Console.WriteLine($"--- Printing Report for {typeof(T).Name} ---");
            foreach (var item in _items)
            {
                // Direct access to interface members without casting:
                item.PrintDetails();
            }
        }
        #endregion
    }
    #endregion
}
