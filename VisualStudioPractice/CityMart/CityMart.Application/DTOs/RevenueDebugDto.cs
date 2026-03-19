namespace CityMart.Application.DTOs
{
    public class RevenueDebugDto
    {
        public decimal TotalRevenue { get; set; }
        public int OrderItemCount { get; set; }
        public IEnumerable<SimpleOrderItemDto> RecentOrderItems { get; set; } = new List<SimpleOrderItemDto>();
    }

    public class SimpleOrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
