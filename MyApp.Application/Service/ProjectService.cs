using MyApp.Application.Interface;
using MyApp.Domain.Entities.Project;
using MyApp.Domain.Object;
using Stripe;
using System;
using System.Collections.Generic;

namespace MyApp.Application.Service
{
    public class ProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        // Create new Project
        public Project CreateProject(string name, string description, Status status, int createdBy, TimeStamp timestamp)
        {
            var project = new Project
            {
                Name = name,
                Description = description,
                Status = status,
                CreatedBy = createdBy,
                TimeStamp = timestamp,
            };
            return _repository.Add(project);
        }

        // Get all Projects
        public IEnumerable<Project> GetAllProjects()
        {
            return _repository.GetAll();
        }

        // Get Project by Id
        public Project? GetProjectById(int id)
        {
            return _repository.GetById(id);
        }

        // Update Project
        public void UpdateProject(int id, string name, string description, Status status, int createdBy, TimeStamp timestamp)
        {
            var project = _repository.GetById(id);
            if (project == null) return;

            project.Name = name;
            project.Description = description;
            project.Status = status;
            project.CreatedBy = createdBy;
            project.TimeStamp = timestamp;
            _repository.Update(project);
        }
        

        // Delete Project
        public void DeleteProject(int id)
        {
             _repository.Delete(id);
        }
    }
}
