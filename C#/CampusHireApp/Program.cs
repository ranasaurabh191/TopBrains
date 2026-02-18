using System;
using CampusHireApp;

class Program
{
    static ApplicantService service = new ApplicantService();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("===== CampusHire Applicant Management =====");
            Console.WriteLine("1. Add Applicant");
            Console.WriteLine("2. View All Applicants");
            Console.WriteLine("3. Search Applicant by ID");
            Console.WriteLine("4. Update Applicant");
            Console.WriteLine("5. Delete Applicant");
            Console.WriteLine("6. Exit");
            Console.Write("Choice: ");

            switch (Console.ReadLine())
            {
                case "1": AddApplicant(); break;
                case "2": ViewAll(); break;
                case "3": Search(); break;
                case "4": Update(); break;
                case "5": Delete(); break;
                case "6": return;
                default: Console.WriteLine("Invalid choice"); break;
            }

            Console.WriteLine("\nPress Enter...");
            Console.ReadLine();
        }
    }

    static void AddApplicant()
    {
        try
        {
            var a = ReadApplicant();
            service.AddApplicant(a);
            Console.WriteLine("Applicant added successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ViewAll()
    {
        var list = service.GetAllApplicants();
        if (list.Count == 0)
        {
            Console.WriteLine("No applicants found.");
            return;
        }

        foreach (var a in list)
            Console.WriteLine(a);
    }

    static void Search()
    {
        Console.Write("Enter Applicant ID: ");
        var id = Console.ReadLine();

        var a = service.SearchById(id);
        Console.WriteLine(a == null ? "Applicant not found." : a.ToString());
    }

    static void Update()
    {
        try
        {
            Console.Write("Enter Applicant ID to update: ");
            var id = Console.ReadLine();

            var a = ReadApplicant();
            a.ApplicantId = id;

            service.UpdateApplicant(a);
            Console.WriteLine("Applicant updated successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void Delete()
    {
        try
        {
            Console.Write("Enter Applicant ID to delete: ");
            var id = Console.ReadLine();

            service.DeleteApplicant(id);
            Console.WriteLine("Applicant deleted successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static Applicant ReadApplicant()
    {
        Console.Write("Applicant ID: ");
        string id = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Current Location (Mumbai/Pune/Chennai): ");
        string current = Console.ReadLine();

        Console.Write("Preferred Location: ");
        string preferred = Console.ReadLine();

        Console.Write("Core Competency (.NET/JAVA/ORACLE/Testing): ");
        string skill = Console.ReadLine();

        Console.Write("Passing Year: ");
        int year = int.Parse(Console.ReadLine());

        return new Applicant
        {
            ApplicantId = id,
            Name = name,
            CurrentLocation = current,
            PreferredLocation = preferred,
            CoreCompetency = skill,
            PassingYear = year
        };
    }
}
