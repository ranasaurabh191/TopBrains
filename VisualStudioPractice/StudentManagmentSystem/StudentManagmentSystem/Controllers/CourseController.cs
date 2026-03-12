using Microsoft.AspNetCore.Mvc;
using StudentManagmentSystem.Models;
using StudentManagmentSystem.UnitOfWork;

namespace StudentManagmentSystem.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unit;

        public CourseController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        // LIST
        public IActionResult Index()
        {
            var courses = _unit.Courses.GetAll().ToList();

            courses = courses
                .Select(c =>
                {
                    c.Department = _unit.Departments.GetById(c.DepartmentId);
                    return c;
                })
                .ToList();

            return View(courses);
        }

        // CREATE GET
        public IActionResult Create()
        {
            ViewBag.Departments = _unit.Departments.GetAll();
            return View();
        }

        // CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _unit.Courses.Insert(course);
                _unit.Save();

                return RedirectToAction("Index");
            }

            ViewBag.Departments = _unit.Departments.GetAll();
            return View(course);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var course = _unit.Courses.GetById(id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        // EDIT GET
        public IActionResult Edit(int id)
        {
            var course = _unit.Courses.GetById(id);

            if (course == null)
                return NotFound();

            ViewBag.Departments = _unit.Departments.GetAll();
            return View(course);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _unit.Courses.Update(course);
                _unit.Save();

                return RedirectToAction("Index");
            }

            ViewBag.Departments = _unit.Departments.GetAll();
            return View(course);
        }

        // DELETE GET
        public IActionResult Delete(int id)
        {
            var course = _unit.Courses.GetById(id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _unit.Courses.Delete(id);
            _unit.Save();

            return RedirectToAction("Index");
        }
    }
}