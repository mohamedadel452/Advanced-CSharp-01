using System;

namespace Advanced_CSharp_01
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

    #region Q16: Contravariance (in T) - Consumer Pattern
    /// <summary>
    /// Contravariant interface (Q16).
    /// 'in' keyword specifies that T is only passed in (consumed) as arguments.
    /// Enables assigning base generic to derived generic:
    /// IConsumer<Animal> can be assigned to IConsumer<Dog>.
    /// </summary>
    public interface IConsumer<in T>
    {
        void Consume(T item);
    }

    public class AnimalFeeder : IConsumer<Animal>
    {
        public void Consume(Animal item)
        {
            Console.WriteLine($"Feeding food to {item.Name}...");
            item.Speak();
        }
    }
    #endregion

}
