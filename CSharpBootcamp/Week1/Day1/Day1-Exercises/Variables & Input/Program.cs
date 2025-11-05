namespace Variables___Input
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variables & Input
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter yor age");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Hi {name}, you are {age} years old!");
        }
    }
}
