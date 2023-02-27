using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null;
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
}
