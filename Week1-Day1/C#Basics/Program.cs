namespace C_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Print to Console
            Console.WriteLine("Hello, World! I am learning C#");

            //Variables & Input
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter yor age");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Hi {name}, you are {age} years old!");

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

            //Loop Practice
            for (int i = 1; i <= 50; i++)
            {
                if (!(i % 2 == 0))
                    Console.WriteLine(i);
            }

            //Method practice
            Console.WriteLine("Enter a number");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(SquareANumber(number));

            //Simple Student Info App
            Console.WriteLine("Enter student name");
            string studentName = Console.ReadLine();
            Console.WriteLine("Enter class");
            string className = Console.ReadLine();
            Console.WriteLine("Enter roll no");
            int rollNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter English marks");
            int englishMarks = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Maths marks");
            int mathsMarks = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Science marks");
            int scienceMarks = Convert.ToInt32(Console.ReadLine());

            double average = (englishMarks + mathsMarks + scienceMarks) / 3;
            string result;
            if (average > 40)
            {

                result = "Pass";
            }
            else
            {
                result = "Fail";
            }

            Console.WriteLine($"Student Profile\n ----------\nName     :{studentName}\nClass    :{className}\nRollNo   :{rollNo}\nResult   :{result}");
        }

        private static int SquareANumber(int n)
        {
            return n * n;
        }
    }
}
