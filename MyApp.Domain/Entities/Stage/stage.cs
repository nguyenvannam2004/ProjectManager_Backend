using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyApp.Domain.Object;

namespace MyApp.Domain.Entities.Project
{
    [Table("Stage")]
    public class Stage
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public Status Status { get; set; }

        [Required]
        public TimeStamp TimeStamp { get; set; }

        public Stage() { }

        public Stage(int id, string name, int projectId, string description, Status status, TimeStamp timeStamp)
        {
            Id = id;
            Name = name;
            ProjectId = projectId;
            Description = description;
            Status = status;
            TimeStamp = timeStamp;
        }
    }
}
