

namespace OOP06_Generics
{
    #region PART 01: THEORETICAL QUESTIONS (Q1 - Q20)
    /*
    ========================================================================================================================
    Q1: What is a generic class? Why use generics?
    ------------------------------------------------------------------------------------------------------------------------
    - What is a Generic Class:
      A class declared with type parameter placeholders (e.g., class Container<T>) that allows developers to defer 
      specifying the concrete data type until the class is declared and instantiated by client code.
    - Why Use Generics:
      1. Type Safety: Type checking occurs at compile time, eliminating invalid cast exceptions (InvalidCastException) at runtime.
      2. Performance & Memory: Completely eliminates Boxing and Unboxing overhead when working with Value Types. 
         (Unlike non-generic ArrayList which boxes every int into an object on the Managed Heap).
      3. Code Reusability: Write an algorithm or data structure once and use it with any type without code duplication.
      4. JIT Optimization: For Value Types, the .NET JIT compiler generates specialized, optimized native machine code 
         per type (e.g., List<int> gets specialized native code). For Reference Types, JIT shares a single machine code 
         implementation because all object references are identical pointer sizes (4 or 8 bytes).

    ========================================================================================================================
    Q3: What are multiple type parameters? Write Pair<TKey, TValue>.
    ------------------------------------------------------------------------------------------------------------------------
    - What are Multiple Type Parameters:
      Generic types can accept more than one type argument (e.g., class Pair<TKey, TValue> or Dictionary<TKey, TValue>).
      Each type parameter operates independently, enabling relationships between distinct types while preserving strong typing.
    - Multiple type parameters let you define a generic type or method whose different parts can independently work with different types.
    ========================================================================================================================
    Q4: What is a generic method? Write Swap<T> method.
    ------------------------------------------------------------------------------------------------------------------------
    - What is a Generic Method:
      A method that introduces its own type parameter (e.g., void Swap<T>(ref T a, ref T b)). 
      Generic methods can exist inside either generic or non-generic classes.
      The C# compiler supports Type Inference, allowing the caller to omit <T> when arguments clearly define it.
    - Implemented in GenericUtilities.cs (demonstrated in Main).
    ========================================================================================================================
     Q5: Write a generic method FindMax<T> that finds maximum value.
    ------------------------------------------------------------------------------------------------------------------------
    - Explanation:
      Because not all types can be compared with the '>' operator, T must be constrained to implement IComparable<T>.
    - Implemented in GenericUtilities.cs (demonstrated in Main).
    ========================================================================================================================

    */
    #endregion


    #region Main Program
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" GENERICS MASTER ASSIGNMENT");


        }
    }

    #endregion

}