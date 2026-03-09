using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagmentSystem.Data;
using StudentManagmentSystem.Models;

namespace StudentManagement.Controllers
{
    public class CourseController : Controller
    {
        private readonly StudentDbContext _context;

        public CourseController(StudentDbContext context)
        {
            _context = context;
        }

        // DISPLAY COURSES
        public IActionResult Index()
        {
            var courses = _context.Courses
                        .Include(c => c.Department)
                        .ToList();

            return View(courses);
        }

        // CREATE COURSE (GET)
        public IActionResult Create()
        {
            ViewBag.Departments = _context.Departments.ToList();
            return View();
        }

        // CREATE COURSE (POST)
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(course);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var course = _context.Courses
                        .Include(c => c.Department)
                        .FirstOrDefault(c => c.CourseId == id);

            if (course == null)
                return NotFound();

            return View(course);
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var course = _context.Courses.Find(id);

            ViewBag.Departments = _context.Departments.ToList();

            return View(course);
        }

        // EDIT (POST)
        [HttpPost]
        public IActionResult Edit(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // DELETE (GET)
        public IActionResult Delete(int id)
        {
            var course = _context.Courses.Find(id);

            return View(course);
        }

        // DELETE (POST)
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
            {
                return NotFound();
            }
            _context.Courses.Remove(course);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // JSON RESULT
        public JsonResult GetCoursesJson()
        {
            var courses = _context.Courses.ToList();

            return Json(courses);
        }

        // CONTENT RESULT
        public ContentResult Message()
        {
            return Content("Course Created Successfully");
        }
    }
}