using System;
using System.Text.RegularExpressions;

class RegistrationValidator
{
    static void Main()
    {
        string email = Console.ReadLine()??"";
        string mobile = Console.ReadLine()??"";
        string password = Console.ReadLine()??"";
        string pan = Console.ReadLine()??"";

        Console.WriteLine($"Email: {(ValidateEmail(email) ? "Valid" : "Invalid")}");
        Console.WriteLine($"Mobile: {(ValidateMobile(mobile) ? "Valid" : "Invalid")}");
        Console.WriteLine($"Password: {(ValidatePassword(password) ? "Valid" : "Invalid")}");
        Console.WriteLine($"PAN: {(ValidatePAN(pan) ? "Valid" : "Invalid")}");
    }

    static bool ValidateEmail(string email)
    {
        return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.(com|in)$");
    }

    static bool ValidateMobile(string mobile)
    {
        return Regex.IsMatch(mobile, @"^(\+91)?[0-9]{10}$");
    }

    static bool ValidatePassword(string password)
    {
        return Regex.IsMatch(password,
            @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$");
    }

    static bool ValidatePAN(string pan)
    {
        return Regex.IsMatch(pan, @"^[A-Z]{5}[0-9]{4}[A-Z]$");
    }
}
