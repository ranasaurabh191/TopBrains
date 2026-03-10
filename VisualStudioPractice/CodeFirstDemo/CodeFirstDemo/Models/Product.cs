using System.ComponentModel.DataAnnotations;

namespace CodeFirstDemo.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        [Range(1, 100000)]
        public double Price { get; set; }

        [Required(ErrorMessage = "Quantity required")]
        [Range(1, 1000)]
        public int Quantity { get; set; }

        [StringLength(300)]
        public string Description { get; set; } = string.Empty;
    }
}