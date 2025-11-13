using Day3_EFCore_Integration.Models;
using Microsoft.EntityFrameworkCore;

namespace Day3_EFCore_Integration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}
