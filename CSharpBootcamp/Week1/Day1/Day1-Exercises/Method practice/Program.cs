namespace Method_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Method practice
            Console.WriteLine("Enter a number");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(SquareANumber(number));
        }

        private static int SquareANumber(int n)
        {
            return n * n;
        }
    }
}
