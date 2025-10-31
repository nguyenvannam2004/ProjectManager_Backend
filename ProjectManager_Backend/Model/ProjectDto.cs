using MyApp.Domain.Object;

namespace ProjectManager_Backend.Model
{
    public class ProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int CreatedBy { get; set; }
        public TimeStamp TimeStamp { get; set; }
    }
}
