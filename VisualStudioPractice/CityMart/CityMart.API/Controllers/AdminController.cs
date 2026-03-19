using CityMart.Application.DTOs;
using CityMart.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CityMart.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }

        // 🔄 Update Order Status
        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus(UpdateOrderStatusDto dto)
        {
            var result = await _service.UpdateOrderStatusAsync(dto);
            return Ok(result);
        }

        // 📊 Dashboard
        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var data = await _service.GetDashboardAsync();
            return Ok(data);
        }

        // 📦 All Orders
        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders()
        {
            var data = await _service.GetAllOrdersAsync();
            return Ok(data);
        }
    }
}