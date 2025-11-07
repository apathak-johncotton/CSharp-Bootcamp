namespace Inheritance___Polymorphism
{
    public class Employee
    {
        public string Name { get; set; }
        public decimal BaseSalary { get; set; }

        public virtual decimal CalculateBonus()
        {
            return 0.0M;
        }
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
            Employee e1 = new Manager("Aarav", 80000);
            Employee e2 = new Developer("Vihaan", 60000);
            Console.WriteLine($"{e1.Name} Bonus: {e1.CalculateBonus()}");
            Console.WriteLine($"{e2.Name} Bonus: {e2.CalculateBonus()}");
        }
    }
}
