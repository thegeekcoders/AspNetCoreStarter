using Microsoft.EntityFrameworkCore;

namespace AspNetCoreStarter.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}