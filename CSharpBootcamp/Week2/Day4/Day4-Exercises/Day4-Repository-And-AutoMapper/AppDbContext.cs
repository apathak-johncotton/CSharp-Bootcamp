using Day4_Repository_And_AutoMapper.Models;
using Microsoft.EntityFrameworkCore;

namespace Day4_Repository_And_AutoMapper
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}
