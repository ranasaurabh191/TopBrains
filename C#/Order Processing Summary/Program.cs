
class OrderSystem
{
    static void Main()
    {
        var result = ProcessOrder(101);

        Console.WriteLine($"Total: {result.totalAmount}");
        Console.WriteLine($"Premium: {result.isPremiumCustomer}");
        Console.WriteLine($"Delivery: {result.deliveryStatus}");
    }

    static (decimal totalAmount, bool isPremiumCustomer, string deliveryStatus) ProcessOrder(int orderId)
    {
        decimal totalAmount = 12500;
        bool isPremium = totalAmount > 10000;
        string delivery = isPremium ? "Express" : "Standard";

        return (totalAmount, isPremium, delivery);
    }
}
