using JwtTokenDemo.Models;

namespace JwtTokenDemo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new()
        {
            new Employee { Id = 1, Name = "John Doe", Address = "New York", Gender = "Male", Company = "XYZ Corp", Designation = "Manager" },
            new Employee { Id = 2, Name = "Jane Smith", Address = "California", Gender = "Female", Company = "ABC Ltd", Designation = "Developer" }
        };
        public IEnumerable<Employee> GetAllEmployees() => _employees;

        public Employee GetEmployeeById(int id) => _employees.FirstOrDefault(e => e.Id == id);

        public void AddEmployee(Employee employee)
        {
            employee.Id = _employees.Count + 1;
            _employees.Add(employee);
        }
        public void UpdateEmployee(Employee employee)
        {
            var existingEmployee = GetEmployeeById(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Address = employee.Address;
                existingEmployee.Gender = employee.Gender;
                existingEmployee.Company = employee.Company;
                existingEmployee.Designation = employee.Designation;
            }
        }
        public void DeleteEmployee(int id) => _employees.RemoveAll(e => e.Id == id);
    }

}
