using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Object
{
    public class TimeStamp
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeStamp()
        {
            
        }

        public TimeStamp(DateTime createdAt, DateTime? updatedAt = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
