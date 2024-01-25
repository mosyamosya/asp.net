using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ASp_Lr12_new.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=mydb.db");
        //}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

        {

            Database.EnsureCreated();

        }
    }
}