using Microsoft.AspNetCore.Mvc;
using StudentManagmentSystem.UnitOfWork;
using StudentManagmentSystem.Models;
using System.Diagnostics;

namespace StudentManagmentSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unit;

        public HomeController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            ViewBag.TotalStudents = _unit.Students.GetAll().Count();
            ViewBag.TotalDepartments = _unit.Departments.GetAll().Count();
            ViewBag.TotalCourses = _unit.Courses.GetAll().Count();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}