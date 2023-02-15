using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Education
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
}
