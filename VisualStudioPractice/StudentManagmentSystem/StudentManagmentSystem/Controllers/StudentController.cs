using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentManagmentSystem.Data;
using StudentManagmentSystem.Models;
using System.Reflection.Metadata.Ecma335;

namespace StudentManagmentSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _context;

        public StudentController(StudentDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students
                            .Include(s => s.Department)
                            .ToList();
            
            return View(students);
        }
        
        public IActionResult Create()
        {
            ViewBag.Departments = _context.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = _context.Students
                          .Where(s=>s.StudentId==id)
                          .FirstOrDefault();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var student = _context.Students
                            .FirstOrDefault(s => s.StudentId == id);

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var student = _context.Students
                .Include(s => s.Department)
                .FirstOrDefault(s => s.StudentId == id);

            return View(student);
        }

        public IActionResult Search(string name)
        {
            var students = _context.Students
                            .Where(s => s.Name.Contains(name))
                            .ToList();

            return View("Index", students);
        }
        public IActionResult StudentsOlderThan20()
        {
            var students = _context.Students
                        .Where(s => s.Age > 20)
                        .Include(s => s.Department)
                        .ToList();

            return View("Index", students);
        }
        public IActionResult OrderByName()
        {
            var students = _context.Students
                        .OrderBy(s => s.Name)
                        .Include(s => s.Department)
                        .ToList();

            return View("Index", students);
        }
        public IActionResult CountStudents()
        {
            var totalStudents = _context.Students.Count();

            return Content("Total Students: " + totalStudents);
        }

        public IActionResult GroupByDepartment()
        {
            var result = _context.Students
                        .GroupBy(s => s.DepartmentId)
                        .Select(g => new
                        {
                            Department = g.Key,
                            TotalStudents = g.Count()
                        })
                        .ToList();

            return Json(result);
        }

        public IActionResult TestStatus()
        {
            return Ok("Request Successful");
        }
        public IActionResult TestBadRequest()
        {
            return BadRequest("Bad Request Example");
        }
        public IActionResult TestServerError()
        {
            return StatusCode(500);
        }
        public JsonResult JsonData()
        {
            var students = _context.Students.ToList();

            return Json(students);
        }
        public ContentResult Message()
        {
            return Content("Student Registered Successfully");
        }
        public RedirectResult RedirectToDepartment()
        {
            return Redirect("/Department/Index");
        }
    }
}
