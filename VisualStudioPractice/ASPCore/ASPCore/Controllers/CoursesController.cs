using Microsoft.AspNetCore.Mvc;

namespace ASPCore.Controllers
{
    public class CoursesController : Controller
    {
        
        public IActionResult Index()
        {
            ViewBag.Message = "This is List Courses Action";
            List<string> courses = new List<string>();
            courses.Add("C#.Net");
            courses.Add("ASP.NET");
            courses.Add("C# MVC");
            courses.Add("NET Core");
            ViewBag.Courses = courses;
            return View();
        }
    }
}
