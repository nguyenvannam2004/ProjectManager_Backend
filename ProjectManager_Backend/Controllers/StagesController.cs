using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Service; // StageService
using MyApp.Domain.Entities.Project; // Stage

using MyApp.Domain.Object;
using ProjectManager_Backend.Model;
using System.Collections.Generic;

namespace ProjectManager_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StagesController : ControllerBase
    {
        private readonly StageService _stageService;

        public StagesController(StageService stageService)
        {
            _stageService = stageService;
        }

        
        // GET: api/Stages
        [HttpGet]
        public IActionResult GetAll()
        {
            var stages = _stageService.GetAllStages();
            return Ok(stages);
        }

        // GET: api/Stages/5
        [Authorize(Roles = "ADMIN,LEADER")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var stage = _stageService.GetStageById(id);
            if (stage == null)
                return NotFound();

            return Ok(stage);
        }

        // POST: api/Stages
        [Authorize(Roles = "ADMIN,LEADER")]
        [HttpPost]
        public IActionResult Create([FromBody] StageDto dto)
        {
            var stage = _stageService.CreateStage(dto.Name, dto.Description, dto.Status, dto.ProjectId, dto.TimeStamp);
            return CreatedAtAction(nameof(GetById), new { id = stage.Id }, stage);
        }

        // PUT: api/Stages/5
        [Authorize(Roles = "ADMIN,LEADER")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] StageDto dto)
        {
            var existingStage = _stageService.GetStageById(id);
            if (existingStage == null)
                return NotFound();

            _stageService.UpdateStage(id, dto.Name, dto.Description, dto.Status, dto.ProjectId,dto.TimeStamp);
            return NoContent();
        }

        // DELETE: api/Stages/5
        [Authorize(Roles = "ADMIN,LEADER")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingStage = _stageService.GetStageById(id);
            if (existingStage == null)
                return NotFound();

            _stageService.DeleteStage(id);
            return NoContent();
        }
    }
}
