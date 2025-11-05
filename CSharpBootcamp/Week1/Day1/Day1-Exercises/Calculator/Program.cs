namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Calculator
            int calculatorResult = 0;
            Console.WriteLine("Enter number 1");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number 2");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Choose Operation");
            string operation = Console.ReadLine();

            if (operation == "+")
            {
                calculatorResult = num1 + num2;
            }
            else if (operation == "-")
            {
                calculatorResult = num1 - num2;
            }
            else if (operation == "*")
            {
                calculatorResult = num1 * num2;
            }
            else
            {
                calculatorResult = num1 / num2;
            }
            Console.WriteLine($"Result is {calculatorResult}");
        }
    }
}
