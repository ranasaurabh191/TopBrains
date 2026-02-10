
public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public string Item { get; set; }

    public Stack<Order> AddOrderDetails(int orderId, string customerName, string item)
    {
        Order newOrder = new Order
        {
            OrderId = orderId,
            CustomerName = customerName,
            Item = item
        };

        Program.OrderStack.Push(newOrder);
        return Program.OrderStack;
    }

    public string GetOrderDetails()
    {
        if (Program.OrderStack.Count == 0)
            return string.Empty;

        Order recentOrder = Program.OrderStack.Peek();
        return recentOrder.OrderId + " " + recentOrder.CustomerName + " " + recentOrder.Item;
    }

    public Stack<Order> RemoveOrderDetails()
    {
        if (Program.OrderStack.Count > 0)
        {
            Program.OrderStack.Pop();
        }
        return Program.OrderStack;
    }
}

