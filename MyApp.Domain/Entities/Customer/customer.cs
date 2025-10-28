using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Entities.Customer
{
    [Table("Customers")]
    public class Customer
    {
        [Key] 
        [Required]
        public int Id { get;  set; }
        [Required]
        [MaxLength(100)]
        public string Name { get;  set; }
        [Required]
        [MaxLength(20)]
        public string Phone { get;  set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get;  set; }

        public Customer() { }

        public Customer(int id, string name, string phone, string email)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
        }
    }
}
