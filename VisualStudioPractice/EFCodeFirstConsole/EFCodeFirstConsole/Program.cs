using System;
using System.Linq;
using System.Data.Entity;
using EFCodeFirstConsole.Data;
using EFCodeFirstConsole.Models;

class Program
{
    static void Main()
    {
        using (var context = new AppDbContext())
        {
            context.Database.CreateIfNotExists();
            Console.WriteLine("Database created.");
        }

        SeedData();   // runs safely only once

        while (true)
        {
            ShowMenu();
            HandleMenu();
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("\n===== EMPLOYEE PF MANAGEMENT =====");
        Console.WriteLine("1. Get PF by Employee Name");
        Console.WriteLine("2. Highest PF Paid Employee");
        Console.WriteLine("3. List All Employees");
        Console.WriteLine("4. List All PFs");
        Console.WriteLine("4. Exit");
        Console.Write("Enter choice: ");
    }

    static void HandleMenu()
    {
        if (!int.TryParse(Console.ReadLine(), out int choice))
        {
            Console.WriteLine("Invalid input. Enter number only.");
            return;
        }

        switch (choice)
        {
            case 1: GetPFByName(); break;
            case 2: GetHighestPF(); break;
            case 3: ListEmployees(); break;
            case 4: ListPFs(); break;
            case 5:
                Console.WriteLine("Exiting...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }


    static void SeedData()
    {
        using (var context = new AppDbContext())
        {
            if (context.Employees.Any() || context.PFs.Any())
                return;

            var emp1 = new Employee
            {
                Name = "Rahul",
                Salary = 50000
            };

            var emp2 = new Employee
            {
                Name = "Anita",
                Salary = 60000
            };

            var emp3 = new Employee
            {
                Name = "Vikram",
                Salary = 55000
            };

            context.Employees.Add(emp1);
            context.Employees.Add(emp2);
            context.Employees.Add(emp3);

            context.SaveChanges();  

            context.PFs.Add(new PF
            {
                EmployeeId = emp1.Id,
                PfAmount = 5000
            });

            context.PFs.Add(new PF
            {
                EmployeeId = emp2.Id,
                PfAmount = 7000
            });

            context.PFs.Add(new PF
            {
                EmployeeId = emp3.Id,
                PfAmount = 6000
            });

            context.SaveChanges();  
        }
    }


    static void GetPFByName()
    {
        Console.Write("Enter employee name: ");
        string name = Console.ReadLine() ?? "";

        using (var context = new AppDbContext())
        {
            var pf = context.PFs
                .Include(p => p.Employee)
                .Where(p => p.Employee != null && p.Employee.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                .Select(p => p.PfAmount)
                .FirstOrDefault();

            if (pf > 0)
                Console.WriteLine($"PF Amount of {name} is {pf}");
            else
                Console.WriteLine("Employee or PF not found");
        }
    }

    static void ListPFs()
    {
        using (var context = new AppDbContext())
        {
            var pfs = context.PFs.Include(p => p.Employee).ToList();
            if (!pfs.Any())
            {
                Console.WriteLine("No PF records found");
                return;
            }
            Console.WriteLine("\n--- PF Records ---");
            foreach (var pf in pfs)
            {
                string empName = pf.Employee != null ? pf.Employee.Name : "Unknown";
                Console.WriteLine($"Employee: {empName}, PF Amount: {pf.PfAmount}");
            }
        }
    }
    static void GetHighestPF()
    {
        using (var context = new AppDbContext())
        {
            var result = context.PFs
                .Include(p => p.Employee)
                .Where(p => p.Employee != null)
                .OrderByDescending(p => p.PfAmount)
                .Select(p => new
                {
                    EmployeeName = p.Employee.Name,
                    p.PfAmount
                })
                .FirstOrDefault();

            if (result != null)
            {
                Console.WriteLine("Highest PF Paid Employee:");
                Console.WriteLine($"Name: {result.EmployeeName}");
                Console.WriteLine($"PF Amount: {result.PfAmount}");
            }
            else
            {
                Console.WriteLine("No PF data found");
            }
        }
    }


    static void ListEmployees()
    {
        using (var context = new AppDbContext())
        {
            var employees = context.Employees.ToList();

            if (!employees.Any())
            {
                Console.WriteLine("No employees found");
                return;
            }

            Console.WriteLine("\n--- Employee List ---");
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Salary: {emp.Salary}");
            }
        }
    }
}