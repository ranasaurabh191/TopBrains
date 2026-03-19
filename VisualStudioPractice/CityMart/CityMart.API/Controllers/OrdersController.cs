using CityMart.Application.DTOs;
using CityMart.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CityMart.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        private string GetUserId()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                throw new Exception("User not authenticated properly");

            return userId;
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout(CheckoutDto dto)
        {
            var userId = GetUserId();
            var result = await _service.CheckoutAsync(userId, dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var userId = GetUserId();
            var data = await _service.GetOrdersAsync(userId);
            return Ok(data);
        }

        // Admin: get all orders
        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrders()
        {
            var data = await _service.GetAllOrdersAsync();
            return Ok(data);
        }

        // Admin: update order status
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateOrderStatusDto dto)
        {
            var result = await _service.UpdateOrderStatusAsync(id, dto.Status);
            return Ok(result);
        }

        // Reports / Dashboard
        [Authorize(Roles = "Admin")]
        [HttpGet("/admin/dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var dto = await _service.GetDashboardAsync();
            return Ok(dto);
        }
    }
}