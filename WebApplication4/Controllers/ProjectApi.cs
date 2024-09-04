using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApplication4.DSConn;
using WebApplication4.Models;

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
        [Route("GetProjects")]
        public IActionResult GetProjects()
        {
            var projectList = from p in _Con.Projects
                              join e in _Con.Employees on p.ID equals e.ProRef into employees
                              select new
                              {
                                  p.ID,
                                  p.Title,
                                  p.Description,
                                  p.StartDate,
                                  p.TimeRequired,
                                  p.Status,
                                  p.Attachment,
                                  Employees = employees.Select(emp => new
                                  {
                                      emp.Id,
                                      emp.Name,
                                      emp.Email,
                                      emp.Phone,
                                      emp.Specialty
                                  }).ToList()
                              };

            var jsonResult = JsonConvert.SerializeObject(projectList.ToList(), new JsonSerializerSettings { MaxDepth = 10 });
            return Ok(jsonResult);
        }

        [HttpGet]
        [Route("GetProject/{id}")]
        public IActionResult GetProject(int id)
        {
            var project = (from p in _Con.Projects
                           join e in _Con.Employees on p.ID equals e.ProRef into employees
                           where p.ID == id
                           select new
                           {
                               p.ID,
                               p.Title,
                               p.Description,
                               p.StartDate,
                               p.TimeRequired,
                               p.Status,
                               p.Attachment,
                               Employees = employees.Select(emp => new
                               {
                                   emp.Id,
                                   emp.Name,
                                   emp.Email,
                                   emp.Phone,
                                   emp.Specialty
                               }).ToList()
                           }).SingleOrDefault();

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

            // Update employees if provided
            if (projectUpdate.Employees != null)
            {
                // You might want to handle how employees are updated. 
                // For simplicity, we are just replacing the list here.
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
