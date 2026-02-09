public class Program
{
    public static Stack<Order> OrderStack { get; set; } = new Stack<Order>();

    public static void Main()
    {
        int orderId = int.Parse(Console.ReadLine());
        string customerName = Console.ReadLine();
        string item = Console.ReadLine();

        Order order = new Order();

        order.AddOrderDetails(orderId, customerName, item);

        Console.WriteLine(order.GetOrderDetails());

        order.RemoveOrderDetails();

        Console.WriteLine(OrderStack.Count);
    }
}