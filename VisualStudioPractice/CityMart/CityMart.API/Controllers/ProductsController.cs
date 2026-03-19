using CityMart.Application.DTOs;
using CityMart.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CityMart.Application.Common;
namespace CityMart.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetByIdAsync(id);
            return Ok(data);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(
            string? search,
            decimal? minPrice,
            decimal? maxPrice,
            int page = 1,
            int pageSize = 5)
        {
            var data = await _service.GetFilteredAsync(search, minPrice, maxPrice, page, pageSize);
            return Ok(data);
        }

        [HttpGet("advanced")]
        public async Task<IActionResult> Advanced(
            string? search,
            decimal? minPrice,
            decimal? maxPrice,
            int? categoryId,
            string? sortBy,
            bool isDescending = false,
            int page = 1,
            int pageSize = 5)
        {
            var data = await _service.GetAdvancedAsync(
                search, minPrice, maxPrice,
                categoryId, sortBy, isDescending,
                page, pageSize);

            return Ok(new ApiResponse<IEnumerable<ProductDto>>
            {
                Success = true,
                Message = "Products fetched successfully",
                Data = data
            });
        }
    }
}