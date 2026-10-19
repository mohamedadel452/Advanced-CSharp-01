using System;

namespace OOP06_Generics
{
    #region Q7: Struct Constraint (Value Type Constraint)
    /// <summary>
    /// Demonstrates 'where T : struct' constraint (Q7).
    /// Ensures T is a non-nullable value type (stored on Stack when local, zero heap overhead).
    /// Prevents null assignments, avoids GC allocation, and guarantees value semantics.
    /// </summary>
    public class ValueTypeBox<T> where T : struct
    {
        #region Properties
        public T Value { get; set; }
        public bool HasValue => true; // Guaranteed non-null
        #endregion

        #region Constructors
        public ValueTypeBox(T initialValue)
        {
            Value = initialValue;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Resets the value to the default bitwise zero for this struct.
        /// </summary>
        public void Reset()
        {
            Value = default(T);
        }

        public override string ToString()
        {
            return $"ValueTypeBox<{typeof(T).Name}>: {Value}";
        }
        #endregion
    }
    #endregion
}
