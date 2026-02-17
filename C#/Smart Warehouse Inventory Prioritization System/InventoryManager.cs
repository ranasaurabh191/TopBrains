using System.Collections.Generic;
using System.Linq;

public class InventoryManager
{
    private SortedDictionary<int, List<Product>> inventory = new SortedDictionary<int, List<Product>>();
    private HashSet<string> skuRegistry = new HashSet<string>();

    public void AddProduct(Product product)
    {
        if (skuRegistry.Contains(product.SKU)) throw new DuplicateSKUException($"SKU already exists: {product.SKU}");

        skuRegistry.Add(product.SKU);
        
        if (!inventory.ContainsKey(product.Priority)) inventory[product.Priority] = new List<Product>();

        inventory[product.Priority].Add(product);
        
    }

    public void RemoveProduct(string sku)
    {
        foreach (var priorityGroup in inventory.Values)
        {
            var product = priorityGroup.FirstOrDefault(p => p.SKU == sku);
            if (product != null)
            {
                priorityGroup.Remove(product);
                skuRegistry.Remove(sku);
                return;
            }
        }

        throw new InvalidProductException("Product not found");
    }

    public void UpdateStock(string sku, int newStock, int threshold)
    {
        Product product = FindProduct(sku);
        product.UpdateStock(newStock, threshold);
    }

    public List<Product> GetHighestPriorityProducts()
    {
        if (inventory.Count == 0) return new List<Product>();

        return inventory.First().Value;
    }

    private Product FindProduct(string sku)
    {
        foreach (var priorityGroup in inventory.Values)
        {
            var product = priorityGroup.FirstOrDefault(p => p.SKU == sku);
            if (product != null) return product;
        }

        throw new InvalidProductException("Product not found");
    }
}
