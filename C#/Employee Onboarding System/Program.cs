using System;
using System.Text.RegularExpressions;

abstract class Employee
{
    public abstract void Onboard();
}

interface IProbation
{
    void StartProbation();
}

static class NameExtensions
{
    public static string FormatName(this string fullName)
    {
        var parts = fullName.Split(' ');
        return $"{parts[1].ToUpper()}, {parts[0]}";
    }
}

class NewEmployee : Employee, IProbation
{
    public override void Onboard()
    {
        Console.WriteLine("Employee Onboarded Successfully");
    }

    public void StartProbation()
    {
        Console.WriteLine("Probation Started");
    }
}

class Program
{
    static (bool, string) OnboardEmployee(string email, string empId, string name)
    {
        bool isValidEmail = Regex.IsMatch(email, @"^[^@]+@[^@]+\.(com|in)$");
        bool isValidId = Regex.IsMatch(empId, @"^EMP-\d{4}$");

        if (!isValidEmail || !isValidId)  return (false, "Validation Failed");

        Console.WriteLine(name.FormatName());

        Employee emp = new NewEmployee();
        emp.Onboard();

        return (true, "Employee Onboarded Successfully");
    }

    static void Main()
    {
        var result = OnboardEmployee("emp@gmail.com", "EMP-1234", "Rahul Sharma");
        Console.WriteLine(result.message);
    }
}
