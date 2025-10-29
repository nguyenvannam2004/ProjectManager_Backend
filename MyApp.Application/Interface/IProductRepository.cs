using MyApp.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interface
{
    public interface IProductRepository
    {
        Product Add(Product product);
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        void Update(Product product);
        void Delete(int id);
    }
}
