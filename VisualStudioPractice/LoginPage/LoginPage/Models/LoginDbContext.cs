using Microsoft.EntityFrameworkCore;

namespace LoginPage.Models
{
    public class LoginDbContext : DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options) { }

        public DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(k => k.id);
            });
            builder.Entity<UserLogin>().HasData(
               new UserLogin { id = 101, UserName = "Gaurav", passCode = "pass@123", isActive = 1 },
               new UserLogin { id = 102, UserName = "Kundan", passCode = "pass@123", isActive = 1 }
           );
        }

    }
}
