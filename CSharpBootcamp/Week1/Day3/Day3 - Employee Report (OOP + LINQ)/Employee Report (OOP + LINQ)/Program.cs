namespace Employee_Report__OOP___LINQ_
{
    public class Employee
    {
        public string Name { get; set; }
        public decimal BaseSalary { get; set; }

        public virtual decimal CalculateBonus()
        {
            return 0.0M;
        }

        public decimal TotalCompensation => BaseSalary + CalculateBonus();
    }

    public class Manager : Employee
    {

        public Manager(string name, decimal baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
        }
        public override decimal CalculateBonus()
        {
            return (20 / 100) * BaseSalary;
        }
    }

    public class Developer : Employee
    {
        public Developer(string name, decimal baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
        }
        public override decimal CalculateBonus()
        {
            return (10 / 100) * BaseSalary;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Manager("Alice", 80000),
                new Manager("Bob", 90000),
                new Developer("Charlie", 60000),
                new Developer("Diana", 70000)
            };

            var totalPayroll = employees.Sum(e => e.TotalCompensation);
            Console.WriteLine($"Total Payroll: {totalPayroll:C}");

            var avgSalaryPerRole = employees
                .GroupBy(e => e.GetType().Name)
                .Select(g => new
                {
                    Role = g.Key,
                    AvgSalary = g.Average(e => e.BaseSalary)
                });

            foreach (var role in avgSalaryPerRole)
            {
                Console.WriteLine($"{role.Role} - Average Salary: {role.AvgSalary:C}");
            }

            var highestEarner = employees
                .OrderByDescending(e => e.TotalCompensation)
                .First();

            Console.WriteLine($"Highest Earner: {highestEarner.Name} ({highestEarner.GetType().Name}) - {highestEarner.TotalCompensation:C}");


        }
    }
}
