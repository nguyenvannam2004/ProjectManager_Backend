using MyApp.Domain.Entities.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interface
{
    public interface ITaskRepository
    {
        Tasks Add(Tasks task);
        Tasks GetById(int id);
        IEnumerable<Tasks> GetAll();
        void Update(Tasks task);
        void Delete(int id);
    }
}
