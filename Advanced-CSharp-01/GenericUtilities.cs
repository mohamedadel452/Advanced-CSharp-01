using System;
using System.Collections.Generic;

namespace OOP06_Generics
{
    #region GenericUtilities Static Class
    /// <summary>
    /// Utility class containing Generic Methods (Q4 & Q5).
    /// Generic methods declare type parameters independently of their containing class.
    /// </summary>
    public static class GenericUtilities
    {
        #region Q4: Swap<T> Method
        /// <summary>
        /// Swaps two variables of any type T in-place using references (Q4).
        /// JIT compiler generates specialized, zero-overhead machine instructions for value types.
        /// </summary>
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        #endregion
      
        #region Q5: FindMax<T> Methods
        /// <summary>
        /// Finds the maximum of two values of type T constrained to IComparable<T> (Q5).
        /// </summary>
        public static T FindMax<T>(T a, T b) where T : IComparable<T>
        {
            // CompareTo returns > 0 if a is greater than b
            return a.CompareTo(b) >= 0 ? a : b;
        }

        /// <summary>
        /// Finds the maximum value across a collection of items of type T (Q5).
        /// </summary>
        public static T FindMax<T>(IEnumerable<T> items) where T : IComparable<T>
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            using var enumerator = items.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException("Collection contains no elements.");
            }

            T max = enumerator.Current;
            while (enumerator.MoveNext())
            {
                if (enumerator.Current.CompareTo(max) > 0)
                {
                    max = enumerator.Current;
                }
            }
            return max;
        }
        #endregion

    }
    #endregion
}
