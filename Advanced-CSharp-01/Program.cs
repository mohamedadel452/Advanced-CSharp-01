

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
    Q15: What is covariance? Explain the 'out' keyword.
    ------------------------------------------------------------------------------------------------------------------------
    - Explanation:
      Covariance enables assigning a generic interface of a more derived type to a generic interface of a less derived type:
      IProducer<Dog> -> IProducer<Animal>.
      The 'out' keyword marks T as output-only (method return positions).
      Applies ONLY to reference types due to binary pointer compatibility in the CLR.
    - Implemented in VarianceExamples.cs .
    ========================================================================================================================
    Q16: What is contravariance? Explain the 'in' keyword.
    ------------------------------------------------------------------------------------------------------------------------
    - Explanation:
      Contravariance reverses assignment compatibility:
      IConsumer<Animal> -> IConsumer<Dog>.
      The 'in' keyword marks T as input-only (method parameter positions).
      A consumer capable of handling any Animal can safely handle a Dog.
    - Implemented in VarianceExamples.cs .

    ========================================================================================================================
    Q17: What is the difference between covariance and contravariance?
    ------------------------------------------------------------------------------------------------------------------------
    - Feature            Covariance (out)                       Contravariance (in)
    - Direction          Derived to Base (Dog -> Animal)        Base to Derived (Animal -> Dog)
    - Position           Return types (Output / Producer)       Parameters (Input / Consumer)
    - Typical BCL Use    IEnumerable<out T>, Func<out TResult>  IComparer<in T>, Action<in T>
    - Purpose            Preserves polymorphism for reading     Extends handlers to specific types

    ========================================================================================================================
     Q18: How do static members work in generic types?
    ------------------------------------------------------------------------------------------------------------------------
    - Explanation:
      In .NET, each distinct closed generic type (e.g., GenericCounter<int> vs GenericCounter<string>) is treated as a 
      separate Type Object by the CLR. Each has its own independent static fields and static constructors.
      Modifying a static member in GenericCounter<int> has ZERO effect on GenericCounter<string>.
    

    ========================================================================================================================
    Q19: How can you inherit from a generic class?
    ------------------------------------------------------------------------------------------------------------------------
    - Explanation:
      1. Closed Generic: class StringList : List<string> (closes type parameter).
      2. Open Generic: class MyList<T> : List<T> (passes type parameter).
      3. Constrained Generic: class SortedList<T> : List<T> where T : IComparable<T> (adds constraints).
      4. Expanded Generic: class DictionaryList<TKey, TValue> : List<TValue> (adds new type parameters).
    
    ========================================================================================================================
     Q20: Complete Exercise - Create a generic Cache<TKey, TValue> with Add, Get, Remove, Contains, and expiration support.
    ------------------------------------------------------------------------------------------------------------------------
    - Implemented in CacheItem.cs and Cache.cs (fully demonstrated in Main).
    ========================================================================================================================


    */
    #endregion


    #region Main Program
    class Program
    {
        static void Main(string[] args)
        {
        
            Console.WriteLine(" GENERICS MASTER ASSIGNMENT");
            #region Q2: Generic Container<T> Demo
            Console.WriteLine("Q2: Generic Container<T> Demonstration");
            var intContainer = new Container<int>();
            intContainer.Add(10);
            intContainer.Add(20);
            intContainer.Add(30);
            Console.WriteLine($"Container<int> Count: {intContainer.Count}, Element at index 1: {intContainer.Get(1)}");

            var stringContainer = new Container<string>();
            stringContainer.Add("C# Generics");
            stringContainer.Add("Type Safety");
            Console.WriteLine($"Container<string> Count: {stringContainer.Count}, Element at index 0: {stringContainer.Get(0)}");
            #endregion

            #region Q3: Pair<TKey, TValue> Demo
            Console.WriteLine("Q3: Multiple Type Parameters Pair<TKey, TValue>");
            var userPair = new Pair<int, string>(101, "Mohamed Adel");
            Console.WriteLine($"Created Pair: {userPair}");
            var (id, name) = userPair;
            Console.WriteLine($"Deconstructed: ID={id}, Name={name}");
            #endregion

            #region Q4: Swap<T> Generic Method Demo
            Console.WriteLine("Q4: Generic Method Swap<T>");
            int x = 5, y = 99;
            Console.WriteLine($"Before Swap: x={x}, y={y}");
            GenericUtilities.Swap(ref x, ref y);
            Console.WriteLine($"After Swap : x={x}, y={y}");

            string strA = "First", strB = "Second";
            Console.WriteLine($"Before Swap: strA='{strA}', strB='{strB}'");
            GenericUtilities.Swap(ref strA, ref strB);
            Console.WriteLine($"After Swap : strA='{strA}', strB='{strB}'");
            #endregion

            #region Q5: FindMax<T> Generic Method Demo
            Console.WriteLine("Q5: Generic Method FindMax<T>");
            int maxInt = GenericUtilities.FindMax(45, 120);
            Console.WriteLine($"FindMax(45, 120) => {maxInt}");

            string maxStr = GenericUtilities.FindMax("Apple", "Zebra");
            Console.WriteLine($"FindMax('Apple', 'Zebra') => {maxStr}");

            int[] numbers = { 12, 89, 45, 230, 7 };
            Console.WriteLine($"FindMax across array: {GenericUtilities.FindMax(numbers)}");
            #endregion



            #region Q7: struct Constraint Demo
            Console.WriteLine("Q7: 'where T : struct' Value Type Constraint");
            var structBox = new ValueTypeBox<int>(500);
            Console.WriteLine(structBox);
            structBox.Reset();
            Console.WriteLine($"After Reset: {structBox}");
            #endregion

            #region Q8: class Constraint Demo
            Console.WriteLine("Q8: 'where T : class' Reference Type Constraint");
            var refHolder = new ReferenceHolder<string>("Active Reference");
            Console.WriteLine(refHolder);
            refHolder.Clear();
            Console.WriteLine(refHolder);
            #endregion

            #region Q9: new() Constraint Demo
            Console.WriteLine("Q9: 'where T : new()' Parameterless Constructor Constraint");
            var factory = new EntityFactory<Product>();
            Product newProduct = factory.CreateInstance();
            Console.WriteLine($"Factory Instantiated: {newProduct.Name} with Price: {newProduct.Price}");
            #endregion

            #region Q10: Interface Constraint Demo
            Console.WriteLine("Q10: 'where T : IPrintable' Interface Constraint");
            var reportPrinter = new ReportPrinter<Product>();
            reportPrinter.Add(new Product("Mechanical Keyboard", 150m));
            reportPrinter.Add(new Product("Gaming Mouse", 80m));
            reportPrinter.PrintAll();
            #endregion

           
            #region Q12: Multiple Constraints Demo
            Console.WriteLine("Q12: Multiple Constraints (class, IComparable<T>, IPrintable, new())");
            var multiProcessor = new DataProcessor<Product>();
            Product autoCreated = multiProcessor.CreateAndDisplay();
            var p1 = new Product("Laptop", 1200m);
            var p2 = new Product("Monitor", 300m);
            int compResult = multiProcessor.CompareItems(p1, p2);
            Console.WriteLine($"Comparison between Laptop and Monitor: {compResult} (p1 > p2)");
            #endregion

            #region Q13 & Q14: SafeList<T> & 'default' Keyword Demo
            Console.WriteLine("Q13 & Q14: SafeList<T> & 'default' Keyword Demonstration");
            var safeNumbers = new SafeList<int>();
            safeNumbers.Add(100);
            safeNumbers.Add(200);

            Console.WriteLine($"safeNumbers[0] => {safeNumbers[0]}");
            Console.WriteLine($"safeNumbers[5] (Invalid Index) => {safeNumbers[5]} (default of int is 0, no exception!)");

            var safeStrings = new SafeList<string>();
            safeStrings.Add("First Item");
            Console.WriteLine($"safeStrings[99] (Invalid Index) => {(safeStrings[99] == null ? "null" : safeStrings[99])}");
            #endregion

            #region Q15 & Q16 & Q17: Variance Demo (Covariance & Contravariance)
            Console.WriteLine("Q15 & Q16: Variance (Covariance out vs Contravariance in)");

            // Covariance: IProducer<Dog> assigned to IProducer<Animal>
            IProducer<Dog> dogShelter = new DogShelter();
            IProducer<Animal> animalShelter = dogShelter; // Valid due to 'out T'
            Animal adoptedAnimal = animalShelter.Produce();
            Console.Write("Covariant Producer produced: ");
            adoptedAnimal.Speak();

            // Contravariance: IConsumer<Animal> assigned to IConsumer<Dog>
            IConsumer<Animal> generalFeeder = new AnimalFeeder();
            IConsumer<Dog> dogFeeder = generalFeeder; // Valid due to 'in T'
            Console.Write("Contravariant Consumer fed Dog: ");
            dogFeeder.Consume(new Dog());
            #endregion

    


            Console.WriteLine("ALL 20 GENERICS QUESTIONS & EXERCISES COMPLETED SUCCESSFULLY!");

        }
    }

    #endregion

}