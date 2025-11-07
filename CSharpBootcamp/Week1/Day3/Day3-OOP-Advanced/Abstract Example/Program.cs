namespace Abstract_Example
{
    abstract class Vehicle
    {
        public abstract void Start();
    }

    class Car : Vehicle
    {
        public override void Start() => Console.WriteLine("Car started...");
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle v1 = new Car();
            v1.Start();
        }
    }
}
