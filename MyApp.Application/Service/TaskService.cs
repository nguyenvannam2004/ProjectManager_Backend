using MyApp.Application.Interface;
using MyApp.Domain.Entities.Task;
using MyApp.Domain.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = MyApp.Domain.Entities.Task.Tasks;
namespace MyApp.Application.Service
{
    public class TaskService 
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        // Tạo mới Task
        public Task CreateTask(int stagedId, string name, string description, int createBy, Status status, TimeStamp timeStamp )
        {
            // Gọi constructor rỗng (tự động tạo TimeStamp)
            var task = new Tasks 
            {
                StagedId = stagedId,
                Name = name,
                Description = description,
                CreateBy = createBy,
                Status = status,
                TimeStamp = timeStamp
            };
            return _repository.Add(task);
        }

        // Lấy tất cả Task
        public IEnumerable<Task> GetAllTasks()
        {
            return _repository.GetAll();
        }

        // Lấy Task theo Id
        public Task GetTaskById(int id)
        {
            return _repository.GetById(id);
        }

        // Update Task
        public void UpdateTask(int id, int stagedId, string name, string description, Status status, int createBy, TimeStamp timeStamp)
        {
            var task = _repository.GetById(id);
            if (task == null) return;

            // Cập nhật các trường
            task.StagedId = stagedId;
            task.Name = name;
            task.Description = description;
            task.Status = status;
            task.TimeStamp = timeStamp;
            task.CreateBy = createBy;
            _repository.Update(task);
        }

        // Delete Task
        public void DeleteTask(int id)
        {
            _repository.Delete(id);
        }
    }
}
