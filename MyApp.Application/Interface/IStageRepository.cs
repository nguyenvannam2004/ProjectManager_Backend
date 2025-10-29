using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Domain.Entities.Project;

namespace MyApp.Application.Interface
{
    public interface  IStageRepository
    {
        Stage Add(Stage product);
        Stage GetById(int id);
        IEnumerable<Stage> GetAll();
        void Update(Stage product);
        void Delete(int id);
    }
}
