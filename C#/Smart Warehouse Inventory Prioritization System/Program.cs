using System;

public class InventoryException : Exception
{
    public InventoryException(string message) : base(message) { }
}

public class LowStockException : InventoryException
{
    public LowStockException(string message) : base(message) { }
}

public class InvalidProductException : InventoryException
{
    public InvalidProductException(string message) : base(message) { }
}

public class DuplicateSKUException : InventoryException
{
    public DuplicateSKUException(string message) : base(message) { }
}

class Program
{
    static void Main()
    {
        InventoryManager manager = new InventoryManager();

        try
        {
            manager.AddProduct(new Electronics("E101", "Laptop", 1, 50));
            manager.AddProduct(new Perishable("P201", "Milk", 2, 10));
            manager.AddProduct(new FragileItem("F301", "Glass Vase", 1, 5));

            manager.UpdateStock("P201", 3, 5);   
        }
        catch (InventoryException ex)
        {
            Console.WriteLine(ex.Message);
        }

        var criticalItems = manager.GetHighestPriorityProducts();
        foreach (var item in criticalItems)
        {
            Console.WriteLine($"{item.Name} | SKU:{item.SKU} | Stock:{item.Stock}");
        }
    }
}
