using MyApp.Domain.Object;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;


// 3. Namespace của bạn
namespace MyApp.Domain.Entities.Task
{
    // 4. Thêm [Table("Task")] giống như [Table("Product")]
    [Table("Task")]
    public class Tasks 
    {
        // 5. Áp dụng [Key], [Required] và [DatabaseGenerated] cho Id
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int StagedId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public Status Status { get; set; }

        public int CreateBy { get; set; }

        [Required]
        public TimeStamp TimeStamp { get; set; }

        public Tasks()
        {
        }

        // 7. Constructor đầy đủ tham số (giống form của bạn)
        public Tasks(int id, int stagedId, string name, string description, Status status, int createBy, TimeStamp timeStamp)
        {
            Id = id;
            StagedId = stagedId;
            Name = name;
            Description = description;
            Status = status;
            CreateBy = createBy;
            TimeStamp = timeStamp;
        }
    }
}