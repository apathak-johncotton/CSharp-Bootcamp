using System.Text.Json;

namespace File_Writing_and_Reading
{
    public class Employee
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public decimal Salary { get; set; }
    }
        internal class Program
        {
            static void Main(string[] args)
            {
                var employeeList = new List<Employee>()
                {
                    new Employee { Name = "Ankit", Role = "CEO", Salary = 100000000 },
                    new Employee { Name = "Vinod", Role = "VP", Salary = 100000 },
                    new Employee { Name = "Karan", Role = "Director", Salary = 90000 },
                    new Employee { Name = "Devansh", Role = "Manager", Salary = 75000 },
                    new Employee { Name = "Naveen", Role = "Developer", Salary = 60000 }
                };

                using (var writer = new StreamWriter("employee.txt"))
                {
                    writer.WriteLine("Name,Role,Salary");
                    foreach (var employee in employeeList)
                    {
                        writer.WriteLine($"{employee.Name},{employee.Role},{employee.Salary}");
                    }
                }

                using (var reader = new StreamReader("employee.txt"))
                {
                    while (!reader.EndOfStream)
                        Console.WriteLine(reader.ReadLine());
                }
            }
        }
}
