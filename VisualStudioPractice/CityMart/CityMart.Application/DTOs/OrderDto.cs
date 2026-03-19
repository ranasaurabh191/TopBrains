namespace CityMart.Application.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
    }
}