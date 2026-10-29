using System;

namespace Advanced_CSharp_01
{
    #region Q9: new() Constraint (Parameterless Constructor Constraint)
    /// <summary>
    /// Demonstrates 'where T : new()' constraint (Q9).
    /// Enforces that type T must expose a public parameterless constructor.
    /// Allows invoking 'new T()' directly at compile time without slow reflection.
    /// </summary>
    public class EntityFactory<T> where T : new()
    {
        #region Methods
        /// <summary>
        /// Instantiates a new instance of T using its default constructor.
        /// </summary>
        public T CreateInstance()
        {
            return new T(); // Legal only because of the 'new()' constraint!
        }

        /// <summary>
        /// Creates an array of N newly instantiated objects.
        /// </summary>
        public T[] CreateArray(int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
            T[] array = new T[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = new T();
            }
            return array;
        }
        #endregion
    }
    #endregion
}
