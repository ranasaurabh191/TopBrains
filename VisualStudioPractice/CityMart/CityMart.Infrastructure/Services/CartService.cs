using CityMart.Application.DTOs;
using CityMart.Application.Interfaces;
using CityMart.Domain.Entities;
using CityMart.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CityMart.Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddToCartAsync(string userId, AddToCartDto dto)
        {
            Console.WriteLine($"UserId: {userId}, ProductId: {dto.ProductId}");

            if (string.IsNullOrEmpty(userId))
                throw new Exception("UserId is NULL");

            // ✅ Step 1: Validate product
            var productExists = await _context.Products
                .AnyAsync(p => p.Id == dto.ProductId);

            if (!productExists)
                return "Invalid Product";

            // ✅ Step 2: Get cart ID ONLY (no entity tracking)
            var cartId = await _context.Carts
                .Where(c => c.UserId == userId)
                .Select(c => c.Id)
                .FirstOrDefaultAsync();

            // ✅ Step 3: Create cart ONLY if not exists
            if (cartId == 0)
            {
                var newCart = new Cart
                {
                    UserId = userId,
                    CreatedDate = DateTime.Now
                };

                _context.Carts.Add(newCart);
                await _context.SaveChangesAsync();

                cartId = newCart.Id; // use ID only
            }

            // ✅ Step 4: Check existing item
            var existingItem = await _context.CartItems
                .FirstOrDefaultAsync(i => i.CartId == cartId && i.ProductId == dto.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += dto.Quantity;
            }
            else
            {
                _context.CartItems.Add(new CartItem
                {
                    CartId = cartId,
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity
                });
            }

            await _context.SaveChangesAsync();

            return "Item added to cart";
        }

        public async Task<IEnumerable<CartDto?>> GetCartAsync(string userId)
        {
            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null) return new List<CartDto>();

            return cart.Items.Select(i => new CartDto
            {
                ProductId = i.ProductId,
                ProductName = i.Product?.Name??"Unknown",
                Quantity = i.Quantity,
                Price = i.Product?.Price ?? 0
            });
        }

        public async Task<string> UpdateQuantityAsync(int cartItemId, int quantity)
        {
            var item = await _context.CartItems.FindAsync(cartItemId);

            if (item == null) return "Not Found";

            item.Quantity = quantity;

            await _context.SaveChangesAsync();

            return "Updated";
        }

        public async Task<string> RemoveItemAsync(int cartItemId)
        {
            var item = await _context.CartItems.FindAsync(cartItemId);

            if (item == null) return "Not Found";

            _context.CartItems.Remove(item);
            await _context.SaveChangesAsync();

            return "Removed";
        }
    }
}