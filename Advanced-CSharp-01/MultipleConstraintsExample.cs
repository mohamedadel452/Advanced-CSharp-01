using System;

namespace OOP06_Generics
{
    #region Q12: Multiple Constraints
    /// <summary>
    /// Demonstrates applying multiple constraints to a single type parameter (Q12).
    /// Strict C# Ordering Rules:
    /// 1. Primary constraint: 'class' (or base class) must come FIRST.
    /// 2. Secondary constraints: interfaces (IComparable<T>, IPrintable) in the middle.
    /// 3. Constructor constraint: 'new()' must come LAST.
    /// </summary>
    public class DataProcessor<T> where T : class, IComparable<T>, IPrintable, new()
    {
        #region Methods
        /// <summary>
        /// Creates, processes, and prints a newly instantiated item.
        /// </summary>
        public T CreateAndDisplay()
        {
            // 'new()' allows instantiation
            T item = new T();

            // 'IPrintable' allows calling PrintDetails
            item.PrintDetails();

            return item;
        }

        /// <summary>
        /// Compares two items using IComparable<T> and checks null using class constraint.
        /// </summary>
        public int CompareItems(T? first, T? second)
        {
            if (first == null && second == null) return 0;
            if (first == null) return -1;
            if (second == null) return 1;

            return first.CompareTo(second);
        }
        #endregion
    }

    #region Sample Model Satisfying Multiple Constraints
    public class Product : IComparable<Product>, IPrintable
    {
        public string Name { get; set; } = "Default Product";
        public decimal Price { get; set; } = 100m;

        // Satisfies 'new()' constraint:
        public Product() { }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        // Satisfies 'IComparable<Product>':
        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }

        // Satisfies 'IPrintable':
        public void PrintDetails()
        {
            Console.WriteLine($"Product: {Name} | Price: {Price:C}");
        }
    }
    #endregion
    #endregion
}
