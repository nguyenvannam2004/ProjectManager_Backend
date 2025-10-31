using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Service;
using MyApp.Domain.Entities.Project;
using MyApp.Domain.Object;
using ProjectManager_Backend.Model;
using System.Collections.Generic;

namespace ProjectManager_Backend.Controllers
{
    //[Authorize(Roles = "ADMIN,LEADER,STAFF")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectsController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        // GET: api/Projects
        [HttpGet]
        public IActionResult GetAll()
        {
            var projects = _projectService.GetAllProjects();
            return Ok(projects);
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetProjectById(id);
            if (project == null)
                return NotFound();
            return Ok(project);
        }

        // POST: api/Projects
        [Authorize(Roles = "ADMIN,LEADER")]
        [HttpPost]
        public IActionResult Create([FromBody] ProjectDto dto)
        {
            var project = _projectService.CreateProject(
                dto.Name,
                dto.Description,
                dto.Status,
                dto.CreatedBy, 
                dto.TimeStamp
            );
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        // PUT: api/Projects/5
        [Authorize(Roles = "ADMIN,LEADER")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProjectDto dto)
        {
            var existingProject = _projectService.GetProjectById(id);
            if (existingProject == null)
                return NotFound();

            _projectService.UpdateProject(
                id,
                dto.Name,
                dto.Description,
                dto.Status,
                dto.CreatedBy,
                dto.TimeStamp
            );
            return NoContent();
        }

        // DELETE: api/Projects/5
        [Authorize(Roles = "ADMIN")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingProject = _projectService.GetProjectById(id);
            if (existingProject == null)
                return NotFound();

            _projectService.DeleteProject(id);
            return NoContent();
        }
    }
}