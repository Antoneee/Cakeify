using Cakeify.Models;
using Microsoft.EntityFrameworkCore;

namespace Cakeify.Data
{
    public class CakeifyDbContext : DbContext
    {
        public CakeifyDbContext(DbContextOptions<CakeifyDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
