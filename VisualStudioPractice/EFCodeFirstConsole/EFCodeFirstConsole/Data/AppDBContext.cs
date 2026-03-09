using System.Data.Entity;
using EFCodeFirstConsole.Models;

namespace EFCodeFirstConsole.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=EFCodeFirstDB;Integrated Security=True")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<PF> PFs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PF>()
                .HasRequired(p => p.Employee)
                .WithMany(e => e.PFs)
                .HasForeignKey(p => p.EmployeeId)
                .WillCascadeOnDelete(true);
        }
    }
}