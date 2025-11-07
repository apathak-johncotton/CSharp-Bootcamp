using System.Text.Json;

namespace ExpenseTracker
{
    public record Expense(int Id, string Description, decimal Amount, string Date);

    public class Program
    {
        List<Expense> list = new List<Expense>();
        static void Main(string[] args)
        {
            Program instance = new Program();
            instance.UserExpenseInput();
            Console.WriteLine("Do you need to enter more expenses");
            string answer = Console.ReadLine();

            while (answer != null && answer.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                instance.UserExpenseInput();
                Console.WriteLine("Do you need to enter more expenses");
                answer = Console.ReadLine();
            }

            var json = JsonSerializer.Serialize(instance.list, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("expense.json", json);

            var content = File.ReadAllText("expense.json");
            var list1 = JsonSerializer.Deserialize<Expense[]>(content).ToList();
            decimal sum = 0.0m;

            foreach (Expense item in list1)
            {
                sum += item.Amount;
            }

            Console.WriteLine($"Total is {sum}");
        }

        public void UserExpenseInput()
        {
            Console.WriteLine("Enter expense details");
            Console.WriteLine("Enter Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter amount");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter date");
            string date = Console.ReadLine();
            var expense = new Expense(id, description, amount, date);
            list.Add(expense);
        }
    }
}
