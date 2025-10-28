using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities.Customer;
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
    }
}
