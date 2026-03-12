using System.ComponentModel.DataAnnotations;

namespace StudentManagmentSystem.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [StringLength(50)]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        public ICollection<Student>? Students { get; set; }

        public ICollection<Course>? Courses { get; set; }
    }
}