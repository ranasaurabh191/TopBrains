class InsufficientBalanceException : Exception { }
class MinimumBalanceException : Exception { }
class InvalidTransactionException : Exception { }
class Program
{
    static void Main()
    {
        List<BankAccount> accounts = new()
        {
            new SavingsAccount{AccountNumber=1,CustomerName="Rahul",Balance=80000},
            new CurrentAccount{AccountNumber=2,CustomerName="Rohit",Balance=30000},
            new LoanAccount{AccountNumber=3,CustomerName="Amit",Balance=100000}
        };

        Console.WriteLine("Balance > 50000");
        accounts.Where(a => a.Balance > 50000).ToList().ForEach(a => Console.WriteLine(a.CustomerName));

        Console.WriteLine("Total Bank Balance: " + accounts.Sum(a => a.Balance));

        Console.WriteLine("Top 3 Accounts:");
        accounts.OrderByDescending(a => a.Balance).Take(3).ToList().ForEach(a => Console.WriteLine(a.CustomerName));

        Console.WriteLine("Grouped by Type:");
        accounts.GroupBy(a => a.GetType().Name).ToList().ForEach(g =>  Console.WriteLine(g.Key + " : " + g.Count()));
    }
}