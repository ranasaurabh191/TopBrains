using CityMart.Application.DTOs;

namespace CityMart.Application.Interfaces
{
    public interface IOrderService
    {
        Task<string> CheckoutAsync(string userId, CheckoutDto dto);

        Task<IEnumerable<OrderDto>> GetOrdersAsync(string userId);

        // Admin methods
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();

        Task<string> UpdateOrderStatusAsync(int orderId, string status);

        Task<decimal> GetTotalRevenueAsync();

        Task<int> GetTotalOrdersAsync();
        Task<CityMart.Application.DTOs.DashboardDto> GetDashboardAsync();
    }
}
