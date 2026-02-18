class Program
{
    static void Main()
    {
        var d1 = new Doctor { Id = 1, Name = "Dr.Raj", Fee = 500 };
        var p1 = new Patient { Id = 1, Name = "Amit", Disease = "Fever" };

        List<Appointment> appointments = new()
        {
            new Appointment{Doctor=d1,Patient=p1,Date=DateTime.Now}
        };

        Console.WriteLine("Doctors with >0 appointments:");

        appointments.GroupBy(a => a.Doctor).Where(g => g.Count() > 0).ToList().ForEach(g => Console.WriteLine(g.Key.Name));

        Console.WriteLine("Total Revenue: " +  appointments.Sum(a => a.Doctor.Fee));
    }
}