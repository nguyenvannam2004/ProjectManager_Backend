using MyApp.Domain.Object;

namespace ProjectManager_Backend.Model
{
    public class StageDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; } // enum: Pending, InProgress, Completed, Cancelled
        public int ProjectId { get; set; }
        public TimeStamp TimeStamp { get; set; }
    }
}
