using MyApp.Application.Interface;
using MyApp.Infracstructure.Data;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infracstructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Domain.Entities.Customer.Customer c)
        {
            _context.Customers.Add(c);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var entity = _context.Customers.Find(id);
            if (entity == null) return false;

            _context.Customers.Remove(entity);
            return _context.SaveChanges() > 0;
        }

        public List<Domain.Entities.Customer.Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Domain.Entities.Customer.Customer? GetById(int id)
        {
            return _context.Customers.Find(id);
        }

        public bool Update(int id, Domain.Entities.Customer.Customer updated)
        {
            var entity = _context.Customers.Find(id);
            if (entity == null) return false;

            // Cập nhật từng trường
            entity.Name = updated.Name;
            entity.Phone = updated.Phone;
            entity.Email = updated.Email;

            _context.Customers.Update(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
