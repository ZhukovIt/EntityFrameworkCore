using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Project
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null;

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = helloapp.db");
        }
    }
}
