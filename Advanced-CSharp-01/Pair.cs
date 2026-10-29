using System;

namespace Advanced_CSharp_01
{
    #region Pair<TKey, TValue> Class
    /// <summary>
    /// Demonstrates multiple generic type parameters (Q3).
    /// Couples two independent, strongly-typed values without requiring boxing or casting.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class Pair<TKey, TValue>
    {
        #region Properties
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        #endregion

        #region Constructors
        public Pair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Allows C# tuple-like deconstruction: var (k, v) = pair;
        /// </summary>
        public void Deconstruct(out TKey key, out TValue value)
        {
            key = Key;
            value = Value;
        }

        public override string ToString()
        {
            return $"[{Key} => {Value}]";
        }
        #endregion
    }
    #endregion
}
