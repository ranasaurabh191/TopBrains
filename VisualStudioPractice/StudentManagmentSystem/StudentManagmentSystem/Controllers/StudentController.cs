using Microsoft.AspNetCore.Mvc;
using StudentManagmentSystem.Models;
using StudentManagmentSystem.UnitOfWork;

namespace StudentManagmentSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unit;

        public StudentController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        // LIST STUDENTS
        public IActionResult Index()
        {
            var students = _unit.Students
                .Find(s => true)
                .ToList();

            students = students
                .Select(s =>
                {
                    s.Department = _unit.Departments.GetById(s.DepartmentId);
                    return s;
                })
                .ToList();

            return View(students);
        }

        // CREATE GET
        public IActionResult Create()
        {
            ViewBag.Departments = _unit.Departments.GetAll();
            ViewBag.Courses = _unit.Courses.GetAll();

            return View();
        }

        // CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _unit.Students.Insert(student);
                _unit.Save();

                return RedirectToAction("Index");
            }

            ViewBag.Departments = _unit.Departments.GetAll();
            ViewBag.Courses = _unit.Courses.GetAll();

            return View(student);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var student = _unit.Students.GetById(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // EDIT GET
        public IActionResult Edit(int id)
        {
            var student = _unit.Students.GetById(id);

            if (student == null)
                return NotFound();

            ViewBag.Departments = _unit.Departments.GetAll();
            ViewBag.Courses = _unit.Courses.GetAll();

            return View(student);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _unit.Students.Update(student);
                _unit.Save();

                return RedirectToAction("Index");
            }

            ViewBag.Departments = _unit.Departments.GetAll();
            ViewBag.Courses = _unit.Courses.GetAll();

            return View(student);
        }

        // DELETE GET
        public IActionResult Delete(int id)
        {
            var student = _unit.Students.GetById(id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _unit.Students.Delete(id);
            _unit.Save();

            return RedirectToAction("Index");
        }

        // SEARCH STUDENT
        public IActionResult Search(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return View("Index", _unit.Students.GetAll());
            }

            var students = _unit.Students
                .Find(s => s.Name != null && s.Name.Contains(name));

            return View("Index", students);
        }

        // FILTER BY DEPARTMENT
        public IActionResult ByDepartment(int id)
        {
            var students = _unit.Students.Find(s => s.DepartmentId == id);
            return View("Index", students);
        }

        // FILTER BY COURSE
        public IActionResult ByCourse(int id)
        {
            var students = _unit.Students.Find(s => s.CourseId == id);
            return View("Index", students);
        }
    }
}