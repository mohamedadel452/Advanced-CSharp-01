using System;

namespace OOP06_Generics
{
    #region Domain Models for Variance
    public class Animal
    {
        public string Name { get; set; } = "Animal";
        public virtual void Speak() => Console.WriteLine($"{Name} makes a sound.");
    }

    public class Dog : Animal
    {
        public Dog() { Name = "Dog"; }
        public override void Speak() => Console.WriteLine("Dog barks: Woof Woof!");
    }
    #endregion

    #region Q15: Covariance (out T) - Producer Pattern
    /// <summary>
    /// Covariant interface (Q15).
    /// 'out' keyword specifies that T is only returned (produced) from methods.
    /// Enables assigning derived generic to base generic:
    /// IProducer<Dog> can be assigned to IProducer<Animal>.
    /// </summary>
    public interface IProducer<out T>
    {
        T Produce();
    }

    public class DogShelter : IProducer<Dog>
    {
        public Dog Produce() => new Dog();
    }
    #endregion


}
