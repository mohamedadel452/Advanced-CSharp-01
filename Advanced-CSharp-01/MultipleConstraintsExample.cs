using System;

namespace Advanced_CSharp_01
{
    #region Base Class for Multiple Type Parameters Model
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }

    public class AuditLog : BaseEntity
    {
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
    #endregion

    #region Q12: Multiple Constraints (Single Type Parameter)
    /// <summary>
    /// Demonstrates applying multiple constraints to a single type parameter (Q12).
    /// Applies: class, IComparable<T>, IPrintable, and new().
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
            T item = new T();
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
    #endregion

    #region Q12: Multiple Constraints (Multiple Type Parameters - Model Solution)
    /// <summary>
    /// Model Solution architecture for Task 12:
    /// Uses multiple type parameters (TEntity, TItem) with where clauses combining:
    /// - Base class constraint: where TEntity : BaseEntity, new()
    /// - Reference type constraint: where TItem : class, IComparable<TItem>, IPrintable, new()
    /// </summary>
    public class DataProcessor<TEntity, TItem>
        where TEntity : BaseEntity, new()
        where TItem : class, IComparable<TItem>, IPrintable, new()
    {
        #region Methods
        public TEntity CreateEntity()
        {
            return new TEntity();
        }

        public TItem CreateItem()
        {
            TItem item = new TItem();
            item.PrintDetails();
            return item;
        }
        #endregion
    }
    #endregion

    #region Sample Model Satisfying Multiple Constraints
    public class Product : IComparable<Product>, IPrintable
    {
        public string Name { get; set; } = "Default Product";
        public decimal Price { get; set; } = 100m;

        public Product() { }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Product: {Name} | Price: {Price:C}");
        }
    }
    #endregion
}
