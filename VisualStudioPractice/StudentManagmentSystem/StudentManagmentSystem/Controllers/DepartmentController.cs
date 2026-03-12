using Microsoft.AspNetCore.Mvc;
using StudentManagmentSystem.Models;
using StudentManagmentSystem.UnitOfWork;

namespace StudentManagmentSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unit;

        public DepartmentController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        // LIST
        public IActionResult Index()
        {
            var departments = _unit.Departments.GetAll();
            return View(departments);
        }

        // CREATE GET
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _unit.Departments.Insert(department);
                _unit.Save();

                return RedirectToAction("Index");
            }

            return View(department);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var department = _unit.Departments.GetById(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        // EDIT GET
        public IActionResult Edit(int id)
        {
            var department = _unit.Departments.GetById(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        // EDIT POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                _unit.Departments.Update(department);
                _unit.Save();

                return RedirectToAction("Index");
            }

            return View(department);
        }

        // DELETE GET
        public IActionResult Delete(int id)
        {
            var department = _unit.Departments.GetById(id);

            if (department == null)
                return NotFound();

            return View(department);
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _unit.Departments.Delete(id);
            _unit.Save();

            return RedirectToAction("Index");
        }
    }
}