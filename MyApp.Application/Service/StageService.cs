using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Application.Interface;
using MyApp.Domain.Entities.Project;
using MyApp.Domain.Object; // chứa enum Status

namespace MyApp.Application.Service
{
    public class StageService
    {
        private readonly IStageRepository _repository;

        public StageService(IStageRepository repository)
        {
            _repository = repository;
        }

        // ✅ Lấy tất cả Stage
        public IEnumerable<Stage> GetAllStages()
        {
            return _repository.GetAll();
        }

        // ✅ Lấy Stage theo Id
        public Stage? GetStageById(int id)
        {
            return _repository.GetById(id);
        }

        // ✅ Lấy Stage theo ProjectId
        //public IEnumerable<Stage> GetStagesByProject(int projectId)
        //{
        //    return _repository.GetByProjectId(projectId);
        //}

        // ✅ Tạo mới Stage
        public Stage CreateStage(string name, string description, Status status, int projectId, TimeStamp timestamp )
        {
            var stage = new Stage
            {
                Name = name,
                Description = description,
                Status = status,
                ProjectId = projectId,
                TimeStamp = timestamp,
            };

            _repository.Add(stage);
            return stage;
        }

        // ✅ Cập nhật Stage
        public void UpdateStage(int id, string name, string description, Status status, int projectId, TimeStamp timestamp)
        {
            var stage = _repository.GetById(id);
            if (stage == null)
                throw new Exception($"Stage with id {id} not found");

            stage.Name = name;
            stage.Description = description;
            stage.Status = status;
            stage.ProjectId = projectId;
            stage.TimeStamp = timestamp;

            _repository.Update(stage);
        }

        // ✅ Xóa Stage
        public void DeleteStage(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
                throw new Exception($"Stage with id {id} not found");

            _repository.Delete(id);
        }
    }
}
