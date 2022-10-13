using Microsoft.EntityFrameworkCore;

namespace Restaurant.Services.Product.API.DbContext
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Models.Product> Products { get; set; }
    }
}
