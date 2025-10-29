using MyApp.Application.Interface;
using MyApp.Domain.Entities.Task;
using MyApp.Infracstructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infracstructure.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;
        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }
        public Tasks Add(Tasks tasks)
        {
            _context.Tasks.Add(tasks);
            _context.SaveChanges();
            return tasks;
        }

        public void Delete(int id)
        {
            var tasks = _context.Tasks.Find(id);
            if (tasks == null) return;
            _context.Tasks.Remove(tasks);
            _context.SaveChanges();
        }

        public IEnumerable<Tasks> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public Tasks GetById(int id)
        {
            return _context.Tasks.Find(id);
        }

        public void Update(Tasks task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }
    }
}
