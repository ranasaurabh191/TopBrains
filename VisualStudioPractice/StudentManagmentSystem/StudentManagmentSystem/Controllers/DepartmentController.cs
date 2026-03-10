using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagmentSystem.Data;
using StudentManagmentSystem.Models;

namespace StudentManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly StudentDbContext _context;

        public DepartmentController(StudentDbContext context)
        {
            _context = context;
        }

        // DISPLAY DEPARTMENTS
        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();
            return View(departments);
        }

        // CREATE DEPARTMENT (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE DEPARTMENT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(department);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var department = _context.Departments
                            .Include(d => d.Students)
                            .FirstOrDefault(d => d.DepartmentId == id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        // EDIT (POST)
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // DELETE (GET)
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        // DELETE (POST)
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            _context.Departments.Remove(department);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // RETURN JSON DATA
        public JsonResult GetDepartmentsJson()
        {
            var departments = _context.Departments.ToList();

            return Json(departments);
        }

        // CONTENT RESULT
        public ContentResult Message()
        {
            return Content("Department Created Successfully");
        }
    }
}