using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.Interface;
using MyApp.Domain.Entities.Project;
using MyApp.Infracstructure.Data;

namespace MyApp.Infracstructure.Repository
{
    public class StageRepository : IStageRepository
    {
        private readonly AppDbContext _context;
        public StageRepository(AppDbContext context)
        {
            _context = context;
        }

        public Stage Add(Stage stage)
        {
            _context.Stages.Add(stage);
            _context.SaveChanges();
            return stage;
        }

        public void Delete(int id)
        {
            var stage = _context.Stages.Find(id);
            if (stage == null) return;
            _context.Stages.Remove(stage);
            _context.SaveChanges();
        }

        public IEnumerable<Stage> GetAll()
        {
            return _context.Stages.ToList();
        }

        public Stage GetById(int id)
        {
            return _context.Stages.Find(id);
        }

        public void Update(Stage stage )
        {
            _context.Stages.Update(stage);
            _context.SaveChanges();
        }
    }
}
