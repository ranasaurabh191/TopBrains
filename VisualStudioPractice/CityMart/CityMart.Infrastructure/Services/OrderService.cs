using CityMart.Application.DTOs;
using CityMart.Application.Interfaces;
using CityMart.Domain.Entities;
using CityMart.Domain.Enums;
using CityMart.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CityMart.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> CheckoutAsync(string userId, CheckoutDto dto)
        {
            // 🔥 Get cart items
            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null || cart.Items == null || !cart.Items.Any())
                return "Cart is empty";

            // 🔥 Create Order
            var order = new Order
            {
                UserId = userId,
                Address = dto.Address,
                Status = OrderStatus.Pending,
                CreatedDate = DateTime.Now,
                Items = new List<OrderItem>()
            };

            decimal total = 0;

            foreach (var item in cart.Items)
            {
                var price = item.Product?.Price ?? 0m;

                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Price = price
                };

                // link explicitly to parent order so EF will insert OrderItem properly
                orderItem.Order = order;

                total += item.Quantity * price;

                order.Items.Add(orderItem);
            }

            order.TotalAmount = total;

            _context.Orders.Add(order);

            // 🔥 Clear cart
            _context.CartItems.RemoveRange(cart.Items);

            await _context.SaveChangesAsync();

            // Debugging logs: print computed total and current DB revenue
            Console.WriteLine($"[Checkout] Computed total: {total}");
            var dbRevenue = await _context.OrderItems.SumAsync(oi => oi.Price * oi.Quantity);
            Console.WriteLine($"[Checkout] DB OrderItems revenue after save: {dbRevenue}");

            return "Order placed successfully";
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAsync(string userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status.ToString(),
                    CreatedDate = o.CreatedDate
                })
                .ToListAsync();
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
                }).ToListAsync();
        }

        public async Task<string> UpdateOrderStatusAsync(int orderId, string status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) return "Not Found";

            if (!Enum.TryParse<OrderStatus>(status, true, out var parsed))
                return "Invalid status";

            order.Status = parsed;
            await _context.SaveChangesAsync();

            return "Status Updated";
        }

        public async Task<decimal> GetTotalRevenueAsync()
        {
            // Compute revenue from order items (price * quantity) to ensure correctness
            // even if Orders.TotalAmount was not populated for older records.
            return await _context.OrderItems.SumAsync(oi => oi.Price * oi.Quantity);
        }

        public async Task<int> GetTotalOrdersAsync()
        {
            return await _context.Orders.CountAsync();
        }

        public async Task<CityMart.Application.DTOs.DashboardDto> GetDashboardAsync()
        {
            var totalOrders = await GetTotalOrdersAsync();
            var totalRevenue = await GetTotalRevenueAsync();
            var totalProducts = await _context.Products.CountAsync();

            return new CityMart.Application.DTOs.DashboardDto
            {
                TotalOrders = totalOrders,
                TotalRevenue = totalRevenue,
                TotalProducts = totalProducts
            };
        }
    }
}