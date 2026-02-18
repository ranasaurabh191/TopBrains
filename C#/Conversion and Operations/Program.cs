using System;

class Program
{
    static void Main()
    {
        // 1. Convert integer Student ID to string
        int studentId = 105;
        string studentIdStr = studentId.ToString();
        Console.WriteLine("Student ID: " + studentIdStr);

        // 2. Convert string "45" to integer
        string seatsStr = "45";
        int availableSeats = int.Parse(seatsStr);
        Console.WriteLine("Available Seats: " + availableSeats);

        // 3. Convert string course fee to decimal
        string courseFeeStr = "15000.50";
        decimal courseFee = decimal.Parse(courseFeeStr);
        Console.WriteLine("Course Fee: " + courseFee);

        // 4. Convert int discount to double
        int discount = 15;
        double discountRate = Convert.ToDouble(discount);
        Console.WriteLine("Discount Rate: " + discountRate);

        // 5. Convert float attendance to double
        float attendance = 92.75f;
        double attendanceDouble = attendance;
        Console.WriteLine("Attendance: " + attendanceDouble);

        // 6. Convert double duration to int
        double duration = 6.8;
        int days = Convert.ToInt32(duration);
        Console.WriteLine("Duration (Days): " + days);

        // 7. Convert double temperature to float
        double temperature = 37.45678;
        float tempFloat = (float)temperature;
        Console.WriteLine("Temperature: " + tempFloat);

        // 8. Convert decimal total amount to formatted string (2 decimal places)
        decimal totalAmount = 12345.6789m;
        string formattedAmount = totalAmount.ToString("F2");
        Console.WriteLine("Total Amount: " + formattedAmount);

        // 9. Convert character grade to numeric (ASCII/Unicode) value
        char grade = 'B';
        int gradeValue = grade;
        Console.WriteLine("Grade Numeric Value: " + gradeValue);

        // 10. Convert boolean value to string
        bool status = false;
        string statusStr = status.ToString();
        Console.WriteLine("Status: " + statusStr);
    }
}
