using CodeFirstDemo.Context;
using CodeFirstDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // LIST
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(emp);
        }

        // EDIT (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var emp = await _context.Employees.FindAsync(id);

            if (emp == null)
                return NotFound();

            return View(emp);
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee emp)
        {
            if (id != emp.EmpID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Employees.Any(e => e.EmpID == emp.EmpID))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(emp);
        }

        // DELETE (GET)
        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmpID == id);

            if (emp == null)
                return NotFound();

            return View(emp);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emp = await _context.Employees.FindAsync(id);

            if (emp != null)
            {
                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var emp = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmpID == id);

            if (emp == null)
                return NotFound();

            return View(emp);
        }
    }
}