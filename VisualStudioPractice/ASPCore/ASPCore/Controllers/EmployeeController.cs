using ASPCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPCore.Controllers
{
    public class EmployeeController : Controller
    {
        //public IActionResult Index()
        //{
        //    ViewData["Message"] = "Welcome to the Employee Management System!";
        //    ViewData["CurrentTime"] = DateTime.Now.ToString("F");
        //    ViewBag.Name = "Ravi";
        //    ViewBag.Id = 1212;
        //    ViewBag.Department = "Engineer";
        //    ViewBag.Salary = 5000;
        //    return View();
        //}

        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee {Id =1,Name="Saurabh",Department = "IT"},
                new Employee {Id =2,Name="Ram",Department = "IT"},
            };
            ViewBag.Company = "ABC TECH";
            ViewData["Loaction"] = "Hyderabad";
            TempData["Message"] = "Welcome to Employee";

            return View(employees);

        }
        public IActionResult Create()
        {
            TempData["Success"] = "Employee added";
            return RedirectToAction("Index");
        }

        
    }
}
