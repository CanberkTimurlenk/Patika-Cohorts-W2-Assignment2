using Microsoft.EntityFrameworkCore;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Entities;

namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        
    }
}
