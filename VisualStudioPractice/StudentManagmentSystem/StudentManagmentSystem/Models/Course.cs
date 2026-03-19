using System.ComponentModel.DataAnnotations;

namespace StudentManagmentSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [StringLength(50)]
        public string? CourseName { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 24, ErrorMessage = "Duration must be between 1 and 24 months")]
        public int Duration { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public Department? Department { get; set; }
    }
}