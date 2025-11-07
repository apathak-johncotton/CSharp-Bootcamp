using System.Text.Json;

namespace JSON_Serialization
{
    public record Employee(string Name, string Role, decimal Salary);
    internal class Program
    {
        static void Main(string[] args)
        {
            var employeeList = new List<Employee>()
            {
                new Employee("Ankit","CEO",100000000),
                new Employee ("Vinod", "VP", 100000),
                new Employee ("Karan", "Director", 90000),
                new Employee ("Devansh", "Manager", 45000),
                new Employee ("Naveen", "Developer", 30000)
            };

            var json = JsonSerializer.Serialize(employeeList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("employee.json", json);

            var content = File.ReadAllText("employee.json");
            var list = JsonSerializer.Deserialize<Employee[]>(content).ToList();

            foreach (Employee item in list)
            {
                if (item.Salary > 50000)
                {
                    Console.WriteLine($"{item.Name},{item.Role},{item.Salary}");
                }
            }

        }
    }
}
