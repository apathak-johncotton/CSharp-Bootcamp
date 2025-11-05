namespace StudentInfoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
    }
}
