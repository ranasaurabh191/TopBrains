using CityMart.Application.DTOs;
using CityMart.Application.Interfaces;
using CityMart.Domain.Enums;
using CityMart.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CityMart.Infrastructure.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> UpdateOrderStatusAsync(UpdateOrderStatusDto dto)
        {
            var order = await _context.Orders.FindAsync(dto.OrderId);

            if (order == null)
                return "Order not found";

            // 🔥 Convert string → enum safely
            if (!Enum.TryParse<OrderStatus>(dto.Status, true, out var status))
                return "Invalid status";

            order.Status = status;

            await _context.SaveChangesAsync();

            return "Order status updated";
        }

        public async Task<DashboardDto> GetDashboardAsync()
        {
            var totalOrders = await _context.Orders.CountAsync();

            var revenue = await _context.Orders
                .Where(o => o.Status == OrderStatus.Delivered)
                .SumAsync(o => (decimal?)o.TotalAmount) ?? 0;

            var products = await _context.Products.CountAsync();

            return new DashboardDto
            {
                TotalOrders = totalOrders,
                TotalRevenue = revenue,
                TotalProducts = products
            };
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status.ToString(),
                    CreatedDate = o.CreatedDate
                })
                .ToListAsync();
        }

        public async Task<RevenueDebugDto> GetRevenueDebugAsync()
        {
            var totalRevenue = await _context.OrderItems.SumAsync(oi => oi.Price * oi.Quantity);
            var count = await _context.OrderItems.CountAsync();

            var recent = await _context.OrderItems
                .OrderByDescending(oi => oi.Id)
                .Take(10)
                .Select(oi => new SimpleOrderItemDto
                {
                    Id = oi.Id,
                    OrderId = oi.OrderId,
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                    Price = oi.Price
                }).ToListAsync();

            return new RevenueDebugDto
            {
                TotalRevenue = totalRevenue,
                OrderItemCount = count,
                RecentOrderItems = recent
            };
        }
    }
}