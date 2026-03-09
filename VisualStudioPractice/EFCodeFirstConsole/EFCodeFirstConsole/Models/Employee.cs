using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstConsole.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]               
        public decimal Salary { get; set; }

        public virtual ICollection<PF> PFs { get; set; }
    }
}