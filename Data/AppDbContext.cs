using Microsoft.EntityFrameworkCore;
using AspNet.Models;

namespace AspNet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Personagens> Personagens { get; set; } = null!;
    }
}