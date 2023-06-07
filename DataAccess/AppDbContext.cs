using Microsoft.EntityFrameworkCore;
using SingletonPatternExample.Models;

namespace SingletonPatternExample.DataAccess
{
    /// <summary>
    /// Db Context to conect to the Db with EF
    /// </summary>
    public class AppDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SingletonExample;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }
    }
}
