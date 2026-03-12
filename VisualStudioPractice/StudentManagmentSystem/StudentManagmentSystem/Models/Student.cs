using System.ComponentModel.DataAnnotations;

namespace StudentManagmentSystem.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
        public int Age { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public int CourseId { get; set; }

        public Department? Department { get; set; }
        public Course? Course { get; set; }

        public DateTime AdmissionDate { get; set; }
    }
}