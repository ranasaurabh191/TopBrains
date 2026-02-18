class Program
{
    static void Main()
    {
        var s1 = new Student { Id = 1, Name = "Rahul" };
        var course = new Course { Id = 1, Name = "C#", Capacity = 2 };

        course.Students.Add(s1);

        Console.WriteLine("Courses with >0 students:");
        
        new List<Course> { course }.Where(c => c.Students.Count > 0).ToList().ForEach(c => Console.WriteLine(c.Name));

        Console.WriteLine("Most Popular Course: " + course.Name);
    }
}