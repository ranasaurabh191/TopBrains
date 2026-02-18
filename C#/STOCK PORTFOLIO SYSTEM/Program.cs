using System;
using System.Collections.Generic;
using System.Linq;

class Investor { public string Name; public decimal Profit; }
class Stock { public string Symbol; }
class Transaction
{
    public Stock Stock;
    public int Quantity;
    public decimal Profit;
}

class Program
{
    static void Main()
    {
        var s1 = new Stock { Symbol = "TCS" };
        var i1 = new Investor { Name = "Rahul", Profit = 20000 };

        List<Transaction> transactions = new()
        {
            new Transaction{Stock=s1,Quantity=10,Profit=20000}
        };

        Console.WriteLine("Most Profitable Investor: " + i1.Name);

        Console.WriteLine("Stock with highest volume:");
        
        transactions.GroupBy(t => t.Stock.Symbol).OrderByDescending(g => g.Sum(x => x.Quantity)).First().Key;
    }
}
