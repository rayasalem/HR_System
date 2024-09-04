using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using WebApplication4.DSConn;
using WebApplication4.Models;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectApi : ControllerBase
    {
        public readonly DBContext _Con;

        public ProjectApi(DBContext con)
        {
            _Con = con;
        }

        [HttpPost]
        [Route("AddProject")]
        public string AddProject([FromBody] Project project)
        {
            _Con.Projects.Add(project);
            _Con.SaveChanges();
            return "Project Added";
        }

        [HttpGet]
        [Route("GetProjects")]
        public string GetProjects()
        {
            var projectList = _Con.Projects.Include(p => p.Employees).ToList();
            JavaScriptSerializer jsData = new JavaScriptSerializer();
            jsData.MaxJsonLength = int.MaxValue;
            return jsData.Serialize(projectList);
        }

        [HttpGet]
        [Route("GetProject/{id}")]
        public string GetProject(int id)
        {
            var project = _Con.Projects.Include(p => p.Employees).SingleOrDefault(p => p.ID == id);
            if (project == null) return "Project not found";

            JavaScriptSerializer jsData = new JavaScriptSerializer();
            return jsData.Serialize(project);
        }

        [HttpPut]
        [Route("EditProject/{id}")]
        public string EditProject(int id, [FromBody] Project projectUpdate)
        {
            var project = _Con.Projects.Include(p => p.Employees).SingleOrDefault(p => p.ID == id);
            if (project == null) return "Project not found";

            project.Title = projectUpdate.Title;
            project.Description = projectUpdate.Description;
            project.StartDate = projectUpdate.StartDate;
            project.TimeRequired = projectUpdate.TimeRequired;
            project.Status = projectUpdate.Status;
            project.Attachment = projectUpdate.Attachment;
            project.Employees = projectUpdate.Employees;

            _Con.Projects.Update(project);
            _Con.SaveChanges();
            return "Project updated";
        }

        [HttpDelete]
        [Route("DeleteProject/{id}")]
        public string DeleteProject(int id)
        {
            var project = _Con.Projects.Include(p => p.Employees).SingleOrDefault(p => p.ID == id);
            if (project == null) return "Project not found";

            _Con.Projects.Remove(project);
            _Con.SaveChanges();
            return "Project deleted";
        }
    }
}
