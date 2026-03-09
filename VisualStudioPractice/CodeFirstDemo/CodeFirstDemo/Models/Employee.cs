using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstDemo.Models
{
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }

        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(100,MinimumLength=3)]
        public string? EmpName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Employee Address is required")]
        [StringLength(300, MinimumLength = 3)]
        public string? Address { get; set; } = null;

        [Required(ErrorMessage = "Salary is Required")]
        [Range(3000, 100000, ErrorMessage = "Salary must be a between 3000 and 100000")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;
    }

}
