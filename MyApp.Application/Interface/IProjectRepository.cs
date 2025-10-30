using MyApp.Domain.Entities.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interface
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAll();
        Project? GetById(int id);
        Project Add(Project project);
        void Update(Project project);
        void Delete(int id);
    }
}
