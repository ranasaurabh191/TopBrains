using CityMart.Application.DTOs;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAllAsync();

    Task<ProductDto?> GetByIdAsync(int id);

    Task<string> CreateAsync(CreateProductDto dto);

    Task<string> DeleteAsync(int id);

    Task<string> UpdateAsync(int id, UpdateProductDto dto);

    Task<IEnumerable<ProductDto>> GetFilteredAsync(
        string? search,
        decimal? minPrice,
        decimal? maxPrice,
        int page,
        int pageSize
    );
    Task<IEnumerable<ProductDto>> GetAdvancedAsync(
        string? search,
        decimal? minPrice,
        decimal? maxPrice,
        int? categoryId,
        string? sortBy,
        bool isDescending,
        int page,
        int pageSize
    );
}