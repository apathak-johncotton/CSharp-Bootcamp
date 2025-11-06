namespace BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var acct = new BankAccount("ACC-001", "Ankit");
            acct.Deposit(500);
            acct.Withdraw(125);
            Console.WriteLine($"Balance: {acct.GetBalance()}");
        }
    }
}
