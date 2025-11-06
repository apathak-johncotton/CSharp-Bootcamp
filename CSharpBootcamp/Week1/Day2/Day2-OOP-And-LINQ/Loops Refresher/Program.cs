namespace Loops_Refresher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintOdds1To100();
            Sum1ToN(5);
            Factorial(5);
        }

        public static void PrintOdds1To100()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (!(i % 2 == 0))
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static void Sum1ToN(int n)
        {
            int sum = 0;
            for (int i=1; i <= n; i++)
            {
                sum += i;
            }
            Console.WriteLine(sum);
        }

        public static void Factorial(int n)
        {
            int ans = 1;
            for(int i=n; i >1; i--)
            {
                ans *= i;
            }
            Console.WriteLine(ans);
        }
    }
}
