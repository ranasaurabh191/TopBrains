using CityMart.Application.DTOs;

namespace CityMart.Application.Interfaces
{
    public interface IAdminService
    {
        Task<string> UpdateOrderStatusAsync(UpdateOrderStatusDto dto);

        Task<DashboardDto> GetDashboardAsync();

        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<RevenueDebugDto> GetRevenueDebugAsync();
    }
}