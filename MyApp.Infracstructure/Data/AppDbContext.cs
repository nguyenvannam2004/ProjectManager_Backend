using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities.Customer;
using MyApp.Domain.Entities.Product;
using MyApp.Domain.Entities.Project;
using MyApp.Domain.Entities.Role;
using MyApp.Domain.Entities.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infracstructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions option) : base (option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Project>().OwnsOne(p => p.TimeStamp);
            modelBuilder.Entity<Stage>().OwnsOne(p => p.TimeStamp);
            modelBuilder.Entity<Tasks>().OwnsOne(p => p.TimeStamp);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Stage> Stages { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Tasks> Tasks { get; set; }

    }
}
