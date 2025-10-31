using MyApp.Domain.Object;

namespace ProjectManager_Backend.Model
{
    public class TaskDto
    {
        public int StagedId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int CreateBy { get; set; }
        public TimeStamp TimeStamp { get; set; }
    }
}
