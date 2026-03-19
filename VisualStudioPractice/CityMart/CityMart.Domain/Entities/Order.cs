using CityMart.Domain.Enums;

namespace CityMart.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string Address { get; set; } = string.Empty;

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}