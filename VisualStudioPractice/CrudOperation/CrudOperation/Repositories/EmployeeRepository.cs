using CrudOperation.Models;

namespace CrudOperation.Repositories
{
    public class EmployeeRepository
    {
        private static List<Employee> employees = new List<Employee>();

       
        public static IEnumerable<Employee> GetAllEmployees
        {
            get { return employees; }
        }

        
        public static void Create(Employee employee)
        {
            employees.Add(employee);
        }
    }
}