using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities.Customer;
using MyApp.Domain.Entities.Product;
using MyApp.Domain.Entities.Role;
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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
