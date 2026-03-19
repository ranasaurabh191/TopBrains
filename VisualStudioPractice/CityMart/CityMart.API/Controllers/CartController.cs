using CityMart.Application.DTOs;
using CityMart.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CityMart.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
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

        [HttpPost]
        public async Task<IActionResult> Add(AddToCartDto dto)
        {
            foreach (var claim in User.Claims)
            {
                Console.WriteLine($"{claim.Type} : {claim.Value}");
            }

            var userId = GetUserId() ?? "";
            var result = await _service.AddToCartAsync(userId, dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = GetUserId() ?? "";
            var data = await _service.GetCartAsync(userId);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, int quantity)
        {
            var result = await _service.UpdateQuantityAsync(id, quantity);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.RemoveItemAsync(id);
            return Ok(result);
        }
    }
}