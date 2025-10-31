using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Service; // ProductService
using MyApp.Domain.Entities.Product; // Product
using ProjectManager_Backend.Model;
using System.Collections.Generic;

namespace ProjectManager_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Create([FromBody] ProductDto dto)
        {
            var product = _productService.CreateProduct(dto.Name, dto.Description, dto.Price);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductDto dto)
        {
            var existingProduct = _productService.GetProductById(id);
            if (existingProduct == null)
                return NotFound();

            _productService.UpdateProduct(id, dto.Name, dto.Description, dto.Price);
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _productService.GetProductById(id);
            if (existingProduct == null)
                return NotFound();

            _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
