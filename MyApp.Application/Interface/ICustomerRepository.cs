using MyApp.Domain.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interface
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer? GetById(int id);
        void Add(Customer c);
        bool Update(int id, Customer updated);
        bool Delete(int id);
    }
}
