using MyApp.Application.Interface;
using MyApp.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Service
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        // Tạo mới Product
        public Product CreateProduct(string name, string description, double price)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                Price = price
            };
            return _repository.Add(product);
        }

        // Lấy tất cả Product
        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }

        // Lấy Product theo Id
        public Product GetProductById(int id)
        {
            return _repository.GetById(id);
        }

        // Update Product
        public void UpdateProduct(int id, string name, string description, double price)
        {
            var product = _repository.GetById(id);
            if (product == null) return;

            product.Name = name;
            product.Description = description;
            product.Price = price;

            _repository.Update(product);
        }

        // Delete Product
        public void DeleteProduct(int id)
        {
            _repository.Delete(id);
        }
    }
}
