using System;
using System.Linq;
using FlexibleInventorySystem.Services;
using FlexibleInventorySystem.Models;
using FlexibleInventorySystem.Utilities;
using FlexibleInventorySystem.Exceptions;

namespace FlexibleInventorySystem
{
    class Program
    {
        private static InventoryManager _inventory = new InventoryManager();

        static void Main(string[] args)
        {
            
            SampleData.Load(_inventory);

            while (true)
            {
                DisplayMenu();
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddProductMenu();
                            break;
                        case "2":
                            RemoveProductMenu();
                            break;
                        case "3":
                            UpdateQuantityMenu();
                            break;
                        case "4":
                            FindProductMenu();
                            break;
                        case "5":
                            ViewAllProducts();
                            break;
                        case "6":
                            GenerateReportsMenu();
                            break;
                        case "7":
                            CheckLowStockMenu();
                            break;
                        case "8":
                            Console.WriteLine("Exiting application. Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }
                catch (InventoryException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine(" FLEXIBLE INVENTORY SYSTEM ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. Update Quantity");
            Console.WriteLine("4. Find Product");
            Console.WriteLine("5. View All Products");
            Console.WriteLine("6. Generate Reports");
            Console.WriteLine("7. Check Low Stock");
            Console.WriteLine("8. Exit");
            Console.WriteLine("=================================");
        }

        static void AddProductMenu()
        {
            Console.WriteLine("\nSelect Product Type:");
            Console.WriteLine("1. Electronic");
            Console.WriteLine("2. Grocery");
            Console.WriteLine("3. Clothing");
            Console.Write("Choice: ");
            string typeChoice = Console.ReadLine();

            Console.Write("ID: ");
            string id = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            Product product = null;

            switch (typeChoice)
            {
                case "1":
                    Console.Write("Brand: ");
                    string brand = Console.ReadLine();

                    Console.Write("Warranty (months): ");
                    int warranty = int.Parse(Console.ReadLine());

                    product = new ElectronicProduct
                    {
                        Id = id,
                        Name = name,
                        Price = price,
                        Quantity = qty,
                        Category = "Electronics",
                        Brand = brand,
                        WarrantyMonths = warranty
                    };
                    break;

                case "2":
                    Console.Write("Expiry Date (yyyy-mm-dd): ");
                    DateTime expiry = DateTime.Parse(Console.ReadLine());

                    product = new GroceryProduct
                    {
                        Id = id,
                        Name = name,
                        Price = price,
                        Quantity = qty,
                        Category = "Groceries",
                        ExpiryDate = expiry,
                        IsPerishable = true
                    };
                    break;

                case "3":
                    Console.Write("Size (XS/S/M/L/XL/XXL): ");
                    string size = Console.ReadLine();

                    Console.Write("Color: ");
                    string color = Console.ReadLine();

                    product = new ClothingProduct
                    {
                        Id = id,
                        Name = name,
                        Price = price,
                        Quantity = qty,
                        Category = "Clothing",
                        Size = size,
                        Color = color
                    };
                    break;

                default:
                    Console.WriteLine("Invalid product type.");
                    return;
            }

            _inventory.AddProduct(product);
            Console.WriteLine("Product added successfully.");
        }

        static void RemoveProductMenu()
        {
            Console.Write("Enter Product ID to remove: ");
            string id = Console.ReadLine();

            bool removed = _inventory.RemoveProduct(id);

            Console.WriteLine(removed
                ? "Product removed successfully."
                : "Product not found.");
        }

        static void UpdateQuantityMenu()
        {
            Console.Write("Enter Product ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter New Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            bool updated = _inventory.UpdateQuantity(id, qty);

            Console.WriteLine(updated
                ? "Quantity updated."
                : "Update failed.");
        }

        static void FindProductMenu()
        {
            Console.Write("Enter Product ID: ");
            string id = Console.ReadLine();

            var product = _inventory.FindProduct(id);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.WriteLine(product);
            Console.WriteLine(product.GetProductDetails());
        }

        static void ViewAllProducts()
        {
            Console.WriteLine("\nALL PRODUCTS:");
            Console.WriteLine("---------------------------------");

            var report = _inventory.GenerateInventoryReport();
            Console.WriteLine(report);
        }

        static void GenerateReportsMenu()
        {
            Console.WriteLine("\nSelect Report Type:");
            Console.WriteLine("1. Inventory Report");
            Console.WriteLine("2. Category Summary");
            Console.WriteLine("3. Value Report");
            Console.WriteLine("4. Expiry Report");

            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine(_inventory.GenerateInventoryReport());
                    break;
                case "2":
                    Console.WriteLine(_inventory.GenerateCategorySummary());
                    break;
                case "3":
                    Console.WriteLine(_inventory.GenerateValueReport());
                    break;
                case "4":
                    Console.Write("Days until expiry: ");
                    int days = int.Parse(Console.ReadLine());
                    Console.WriteLine(_inventory.GenerateExpiryReport(days));
                    break;
                default:
                    Console.WriteLine("Invalid report option.");
                    break;
            }
        }

        static void CheckLowStockMenu()
        {
            Console.Write("Enter stock threshold: ");
            int threshold = int.Parse(Console.ReadLine());

            var lowStock = _inventory.GetLowStockProducts(threshold);

            if (!lowStock.Any())
            {
                Console.WriteLine("No low-stock products.");
                return;
            }

            Console.WriteLine("LOW STOCK PRODUCTS:");
            foreach (var p in lowStock)
                Console.WriteLine(p);
        }
    }
}
