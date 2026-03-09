using CodeFirstDemo.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CodeFirstDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext _employeeContext;

        public EmployeeController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public async Task<ActionResult> Index()
        {
            return _employeeContext.Employees != null ?
                        View(await _employeeContext.Employees.ToListAsync()) :
                        Problem("Entity set 'EmployeeContext.Employees'  is null.");
        }
    }
}
