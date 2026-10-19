using System;
using System.Collections.Generic;

namespace OOP06_Generics
{
    #region GenericUtilities Static Class
    /// <summary>
    /// Utility class containing Generic Methods (Q4 ).
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

    }
    #endregion
}
