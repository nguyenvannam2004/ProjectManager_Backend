
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities.Product
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Required]
        public int Id { get;  set; }

        [Required]
        [MaxLength(100)]
        public string Name { get;  set; }

        [Required]
        [MaxLength(100)]
        public string Description { get;  set; }

        [Required]
        public double Price { get;  set; }

        public Product() { }
        public Product(int id, string name, string description, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
