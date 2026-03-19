using CityMart.Application.DTOs;
using CityMart.Application.Interfaces;
using CityMart.Domain.Entities;
using CityMart.Persistence.Context;
using Microsoft.EntityFrameworkCore;
namespace CityMart.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    CategoryName = p.Category.Name
                }).ToListAsync();
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var p = await _context.Products.Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (p == null) return null;

            return new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                CategoryName = p.Category.Name
            };
        }

        public async Task<string> CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name ?? "",
                Description = dto.Description ?? "",
                Price = dto.Price,
                Stock = dto.Stock,
                ImageUrl = dto.ImageUrl ?? "",
                CategoryId = dto.CategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return "Product Created";
        }

        public async Task<string> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null) return "Not Found";

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return "Deleted";
        }

        public async Task<string> UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null) return "Not Found";

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.ImageUrl = dto.ImageUrl;
            product.CategoryId = dto.CategoryId;

            await _context.SaveChangesAsync();

            return "Updated Successfully";
        }

        public async Task<IEnumerable<ProductDto>> GetFilteredAsync(
                string? search,
                decimal? minPrice,
                decimal? maxPrice,
                int page,
                int pageSize)
        {

            var query = _context.Products.Include(p => p.Category).AsQueryable();

            // 🔍 Search
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.Contains(search));
            }

            // 💰 Price filter
            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice);
            }

            // 📄 Pagination
            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            return await query.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                CategoryName = p.Category.Name
            }).ToListAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAdvancedAsync(
            string? search,
            decimal? minPrice,
            decimal? maxPrice,
            int? categoryId,
            string? sortBy,
            bool isDescending,
            int page,
            int pageSize)
        {   
            var query = _context.Products
                .Include(p => p.Category)
                .AsQueryable();

            // 🔍 Search
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Name.Contains(search));

            // 💰 Price filter
            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice);

            // 🗂️ Category filter
            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId);

            // 🔃 Sorting
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "price":
                        query = isDescending
                            ? query.OrderByDescending(p => p.Price)
                            : query.OrderBy(p => p.Price);
                        break;

                    case "name":
                        query = isDescending
                            ? query.OrderByDescending(p => p.Name)
                            : query.OrderBy(p => p.Name);
                        break;
                }
            }

            // 📄 Pagination
            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            return await query.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                CategoryName = p.Category.Name
            }).ToListAsync();
        }
    }
}