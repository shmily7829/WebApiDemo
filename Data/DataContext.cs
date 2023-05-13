global using Microsoft.EntityFrameworkCore;

namespace WebApiDemo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=SHIH-YUAN\\SQLEXPRESS;Database=superherodb;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
