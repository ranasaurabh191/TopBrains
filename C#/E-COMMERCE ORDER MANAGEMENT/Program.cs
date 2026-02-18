class OutOfStockException : Exception { }
class CustomerBlacklistedException : Exception { }

class Program
{
    static void Main()
    {
        var p1 = new Product { Id = 1, Name = "Laptop", Price = 50000, Stock = 5 };
        var c1 = new Customer { Id = 1, Name = "Rahul", Blacklisted = false };

        if (c1.Blacklisted) throw new CustomerBlacklistedException();
        if (p1.Stock < 1) throw new OutOfStockException();

        var order = new Order
        {
            OrderId = 101,
            Customer = c1,
            Items = { new OrderItem { Product = p1, Quantity = 1 } }
        };

        List<Order> orders = new() { order };

        Console.WriteLine("Total Revenue: " +
            orders.Sum(o => o.Items.Sum(i => i.TotalPrice())));

        Console.WriteLine("Orders last 7 days: " +
            orders.Count(o => o.OrderDate >= DateTime.Now.AddDays(-7)));
    }
}