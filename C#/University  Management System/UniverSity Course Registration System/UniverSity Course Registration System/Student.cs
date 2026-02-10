using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // Student Class
    // =========================
    public class Student
    {
        public string StudentId { get; private set; }
        public string Name { get; private set; }
        public string Major { get; private set; }
        public int MaxCredits { get; private set; }

        public List<string> CompletedCourses { get; private set; }
        public List<Course> RegisteredCourses { get; private set; }

        public Student(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            StudentId = id;
            Name = name;
            Major = major;
            MaxCredits = maxCredits;
            CompletedCourses = completedCourses ?? new List<string>();
            RegisteredCourses = new List<Course>();
        }

        public int GetTotalCredits()
        {
            // TODO: Return sum of credits of all RegisteredCourses
            int sum=0;
            foreach(var course in RegisteredCourses)
            {
                sum+=course.Credits;
            }
            return sum;
            throw new NotImplementedException();
        }

        public bool CanAddCourse(Course course)
        {
            // TODO:
            // 1. Course should not already be registered
            if(RegisteredCourses.Any(c=>c.CourseCode==course.CourseCode)) return false;
            // 2. Total credits + course credits <= MaxCredits
            if(GetTotalCredits() + course.Credits>MaxCredits) return false;
            // 3. Course prerequisites must be satisfied
            if(!course.HasPrerequisites(CompletedCourses)) return false;
            return true;
            throw new NotImplementedException();
        }

        public bool AddCourse(Course course)
        {
            // TODO:
            // 1. Call CanAddCourse
            if(CanAddCourse(course) && !course.IsFull())
            {
                course.EnrollStudent();
                RegisteredCourses.Add(course);
                return true;

            }
            return false;

            
            // 2. Check course capacity

            // 3. Add course to RegisteredCourses
            // 4. Call course.EnrollStudent()
            throw new NotImplementedException();
        }

        public bool DropCourse(string courseCode)
        {
            // TODO:
            // 1. Find course by code
            // 2. Remove from RegisteredCourses
            // 3. Call course.DropStudent()
            Course course = RegisteredCourses.First(c=>c.CourseCode==courseCode);
            if(course==null) return false;
            else RegisteredCourses.Remove(course);
            course.DropStudent();
            throw new NotImplementedException();
        }

        public void DisplaySchedule()
        {
            // TODO:
            // Display course code, name, and credits
            // If no courses registered, display appropriate message
            if(RegisteredCourses.Count==0) Console.WriteLine("No course registerd.");
            foreach (var course in RegisteredCourses)
            {
                Console.WriteLine($"{course.CourseCode} - {course.CourseName} ({course.Credits} Credits)");
            }
            throw new NotImplementedException();
        }
    }
}
