

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
    - Implemented in GenericUtilities.cs 
    ========================================================================================================================
     Q6: What is a generic interface? Write IRepository<T>.
    ------------------------------------------------------------------------------------------------------------------------
    - What is a Generic Interface:
      An interface with type parameters (e.g., IRepository<T>, IEnumerable<T>). 
      It defines a strongly-typed contract that classes can implement without forcing casting or boxing.
    - Implemented in IRepository.cs .

    ========================================================================================================================
    Q7: What is the 'struct' constraint? Write an example.
    ------------------------------------------------------------------------------------------------------------------------
    - Explanation:
      'where T : struct' enforces that T must be a non-nullable Value Type (int, double, custom struct).
      Guarantees stack allocation when used locally, eliminates null references, and prevents passing reference types.
    - Implemented in StructConstraintExample.cs 

    ========================================================================================================================
     Q8: What is the 'class' constraint? Write an example.
    ------------------------------------------------------------------------------------------------------------------------
    - Explanation:
      'where T : class' enforces that T must be a Reference Type (class, interface, delegate, or array).
      Guarantees that T can be checked against null (item == null) and allows reference identity comparison.
    - Implemented in ClassConstraintExample.cs 
    ========================================================================================================================
     Q9: What is the 'new()' constraint? Write an example.
    ------------------------------------------------------------------------------------------------------------------------
    - Explanation:
      'where T : new()' enforces that T must have a public parameterless constructor.
      Allows calling 'new T()' directly inside the generic class without slow reflection.
      When multiple constraints are applied, 'new()' must always be placed LAST.
    - Implemented in NewConstraintExample.cs .
    ========================================================================================================================
    Q10: What is the interface constraint? Write an example.
    ------------------------------------------------------------------------------------------------------------------------
    - Explanation:
      'where T : ISomeInterface' ensures that type T implements the designated interface.
      Allows direct invocation of interface members on generic instances without runtime casting.
    - Implemented in InterfaceConstraintExample.cs 
    ========================================================================================================================
     Q11: What is the base class constraint? Write an example.
    ------------------------------------------------------------------------------------------------------------------------
    - Explanation:
      'where T : BaseClass' enforces that T is either the specified base class or derives from it.
      Exposes all public and protected base members to the generic class at compile time.
    - Implemented in BaseClassConstraintExample.cs .
    ========================================================================================================================
    Q12: How do you apply multiple constraints? Write an example.
    ------------------------------------------------------------------------------------------------------------------------
    - Explanation:
      Multiple constraints are chained with commas: 'where T : class, IComparable<T>, IPrintable, new()'.
      Precedence rule:
      1. Primary Constraint: 'class', 'struct', or a Base Class (at most one, MUST be first).
      2. Secondary Constraints: Interfaces (zero or more).
      3. Constructor Constraint: 'new()' (MUST be last).
    - Implemented in MultipleConstraintsExample.cs .

    ========================================================================================================================
      Q13: What does the 'default' keyword do in generics?
    ------------------------------------------------------------------------------------------------------------------------
    - Explanation:
      In generic code, you cannot assign 0 (if T is string) or null (if T is int).
      'default' or 'default(T)' returns the type-safe default value:
      - null for Reference Types.
      - 0 for numeric Value Types.
      - false for Boolean.
      - Bitwise all-zero initialized struct for custom Value Types.

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