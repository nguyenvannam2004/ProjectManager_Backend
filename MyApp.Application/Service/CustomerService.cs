using MyApp.Application.Interface;
using MyApp.Domain.Entities.Customer;
using System.Collections.Generic;

namespace MyApp.Application.Service
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public List<Customer> GetAll()
        {
            return _repo.GetAll();
        }

        public Customer? GetById(int  id)
        {
            return _repo.GetById(id);
        }

        public void Create(Customer customer)
        {
            _repo.Add(customer);
        }

        public bool Update(int id, Customer updatedCustomer)
        {
            return _repo.Update(id, updatedCustomer);
        }

        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}
