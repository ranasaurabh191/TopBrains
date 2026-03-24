using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private IApplicationDbContext _dbcontext;

        public OrderRepository(IApplicationDbContext dbcontext)
            => _dbcontext = dbcontext;

        public async Task<IEnumerable<Order?>?> GetAllOrder()
        {
            var orders = await _dbcontext.Orders.ToListAsync();
            if (!orders.Any()) return null;
            return orders;
        }

        public async Task<string> Add(Order order)
        {
            _dbcontext.Orders.Add(order);
            await _dbcontext.SaveChanges();
            return order.Id!;
        }

        public async Task<Order?> GetById(string id)
        {
            var order = await _dbcontext.Orders.Where(o => o.Id == id).FirstOrDefaultAsync();
            if (order == null) return null;
            return order;
        }

        public async Task<Order?> GetByCustomerId(string custid)
        {
            var order = await _dbcontext.Orders.Where(o => o.CustomerId == custid).FirstOrDefaultAsync();
            if (order == null) return null;
            return order;
        }

        public async Task<string> Cancel(string id)
        {
            var order = await _dbcontext.Orders.Where(o => o.Id == id).FirstOrDefaultAsync();
            if (order == null) return "Order does not exist";
            order.Status = "Cancelled";
            _dbcontext.Orders.Remove(order);
            await _dbcontext.SaveChanges();
            return "Order Cancelled Successfully";
        }
    }
}
