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
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
        public string? EmpName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Employee Address is required")]
        [StringLength(300, MinimumLength = 3, ErrorMessage = "Address must be between 3 and 300 characters")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Salary is Required")]
        [Range(3000, 100000, ErrorMessage = "Salary must be between 3000 and 100000")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email Address")]
        [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; } = string.Empty;
    }
}