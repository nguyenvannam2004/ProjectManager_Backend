using MyApp.Application.Interface;
using MyApp.Domain.Entities.Project;
using MyApp.Infracstructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infracstructure.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public Project Add(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;
        }

        public void Delete(int id)
        {
            var project = _context.Projects.Find(id);
            if (project == null) return;
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

        public IEnumerable<Project> GetAll()
        {
            return _context.Projects.ToList();
        }

        public Project? GetById(int id)
        {
            return _context.Projects.Find(id);
        }

        public void Update(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }
    }
}