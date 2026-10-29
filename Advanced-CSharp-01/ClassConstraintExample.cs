using System;

namespace Advanced_CSharp_01
{
    #region Q8: Class Constraint (Reference Type Constraint)
    /// <summary>
    /// Demonstrates 'where T : class' constraint (Q8).
    /// Enforces that T must be a reference type (allocated on the Managed Heap).
    /// Allows null checks (item == null), assigning null, and using reference equality.
    /// </summary>
    public class ReferenceHolder<T> where T : class
    {
        #region Properties
        public T? Value { get; private set; }
        public bool IsNull => Value == null;
        #endregion

        #region Constructors
        public ReferenceHolder(T? initialValue = null)
        {
            Value = initialValue;
        }
        #endregion

        #region Methods
        public void Set(T value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value), "Cannot set null value to reference holder.");
        }

        public void Clear()
        {
            Value = null; // Valid only because of 'where T : class'
        }

        public bool IsSameInstance(T other)
        {
            return object.ReferenceEquals(Value, other);
        }

        public override string ToString()
        {
            return IsNull ? "ReferenceHolder is [NULL]" : $"ReferenceHolder contains: {Value}";
        }
        #endregion
    }
    #endregion
}
