using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyApp.Domain.Object;

namespace MyApp.Domain.Entities.Project
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        public TimeStamp TimeStamp { get; set; }

        public Project() { }

        public Project(int id, string name, string description, Status status, int createdBy, TimeStamp timestamp)
        {
            Id = id;
            Name = name;
            Description = description;
            Status = status;
            CreatedBy = createdBy;
            TimeStamp = timestamp;
        }
    }
}
