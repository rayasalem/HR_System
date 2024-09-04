using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication4.DSConn;
using WebApplication4.Models;
using Newtonsoft.Json;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectApi : ControllerBase
    {
        private readonly DBContext _Con;

        public ProjectApi(DBContext con)
        {
            _Con = con;
        }

        [HttpPost]
        [Route("AddProject")]
        public IActionResult AddProject([FromBody] Project project)
        {
            if (project == null)
                return BadRequest("Project data is null");

            _Con.Projects.Add(project);
            _Con.SaveChanges();
            return Ok("Project Added");
        }

        [HttpGet]
        [HttpGet]
        [Route("GetProjects")]
        public IActionResult GetProjects()
        {
           
            var projectList = _Con.Projects
                .Include(p => p.Employees)
                .Select(p => new
                {
                    p.ID,
                    p.Title,
                    p.Description,
                    p.StartDate,
                    p.TimeRequired,
                    p.Status,
                    p.Attachment,
                    Employees = p.Employees.Select(e => new
                    {
                        e.Id,
                        e.Name,
                        e.Email,
                        e.Phone,
                        e.Specialty
                    }).ToList()
                }).ToList();

            var jsonResult = JsonConvert.SerializeObject(projectList, new JsonSerializerSettings { MaxDepth = 10 });
            return Ok(jsonResult);
        }

        [HttpGet]
        [Route("GetProject/{id}")]
        public IActionResult GetProject(int id)
        {
            var project = _Con.Projects
                .Include(p => p.Employees)
                .Where(p => p.ID == id)
                .Select(p => new
                {
                    p.ID,
                    p.Title,
                    p.Description,
                    p.StartDate,
                    p.TimeRequired,
                    p.Status,
                    p.Attachment,
                    Employees = p.Employees.Select(e => new
                    {
                        e.Id,
                        e.Name,
                        e.Email,
                        e.Phone,
                        e.Specialty
                    }).ToList()
                })
                .SingleOrDefault();

            if (project == null)
                return NotFound("Project not found");

            var jsonResult = JsonConvert.SerializeObject(project, new JsonSerializerSettings { MaxDepth = 10 });
            return Ok(jsonResult);
        }

        [HttpPut]
        [Route("EditProject/{id}")]
        public IActionResult EditProject(int id, [FromBody] Project projectUpdate)
        {
            if (projectUpdate == null)
                return BadRequest("Project data is null");

            var project = _Con.Projects
                .Include(p => p.Employees)
                .SingleOrDefault(p => p.ID == id);

            if (project == null)
                return NotFound("Project not found");

            project.Title = projectUpdate.Title;
            project.Description = projectUpdate.Description;
            project.StartDate = projectUpdate.StartDate;
            project.TimeRequired = projectUpdate.TimeRequired;
            project.Status = projectUpdate.Status;
            project.Attachment = projectUpdate.Attachment;

            
            if (projectUpdate.Employees != null)
            {
                project.Employees = projectUpdate.Employees;
            }

            _Con.Projects.Update(project);
            _Con.SaveChanges();
            return Ok("Project updated");
        }

        [HttpDelete]
        [Route("DeleteProject/{id}")]
        public IActionResult DeleteProject(int id)
        {
            var project = _Con.Projects
                .Include(p => p.Employees)
                .SingleOrDefault(p => p.ID == id);

            if (project == null)
                return NotFound("Project not found");

            _Con.Projects.Remove(project);
            _Con.SaveChanges();
            return Ok("Project deleted");
        }
    }
}
