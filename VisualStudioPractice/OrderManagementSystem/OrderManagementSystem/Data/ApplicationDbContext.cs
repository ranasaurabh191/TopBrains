using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Order> Orders { get; set; }

        public new async Task<int> SaveChanges() => await base.SaveChangesAsync();
    }

    public interface IApplicationDbContext
    {
        DbSet<Order> Orders { get; set; }
        Task<int> SaveChanges();
    }
}
