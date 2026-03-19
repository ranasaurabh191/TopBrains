using CityMart.Application.DTOs;

public interface ICartService
{
    Task<string> AddToCartAsync(string userId, AddToCartDto dto);

    Task<IEnumerable<CartDto?>> GetCartAsync(string userId);

    Task<string> UpdateQuantityAsync(int cartItemId, int quantity);

    Task<string> RemoveItemAsync(int cartItemId);
}