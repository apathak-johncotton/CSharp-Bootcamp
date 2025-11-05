namespace Loop_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Loop Practice
            for (int i = 1; i <= 50; i++)
            {
                if (!(i % 2 == 0))
                    Console.WriteLine(i);
            }
        }
    }
}
