using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Service; // TaskService
using MyApp.Domain.Entities.Task; // Tasks
using MyApp.Domain.Object;
using System.Collections.Generic;

namespace ProjectManager_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/Tasks
        [HttpGet]
        public IActionResult GetAll()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        // POST: api/Tasks
        [HttpPost]
        public IActionResult Create([FromBody] TaskDto dto)
        {
            var task = _taskService.CreateTask(
                dto.StagedId,
                dto.Name,
                dto.Description,
                dto.CreateBy,
                dto.Status,
                dto.TimeStamp
            );

            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TaskDto dto)
        {
            var existingProduct = _taskService.GetTaskById(id);
            if (existingProduct == null)
                return NotFound();

            _taskService.UpdateTask(id,dto.StagedId, dto.Name, dto.Description,dto.Status,dto.CreateBy,dto.TimeStamp );
            return NoContent();
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProduct = _taskService.GetTaskById(id);
            if (existingProduct == null)
                return NotFound();

            _taskService.DeleteTask(id);
            return NoContent();
        }
    }

    // DTO để nhận dữ liệu từ client
    public class TaskDto
    {
        public int StagedId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int CreateBy { get; set; }
        public TimeStamp TimeStamp { get; set; }
    }
}
