using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
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

        [HttpGet]
        [Route("AddProj/{title}/{desc}/{status}/{stDate}/{eDate}/{empRe}/{url}")]
        public string AddProject(string title, string desc, string status, string stDate,
            string eDate, string empRe, string url)
        {
            Project project = new Project();
            project.ProjectTitle = title;
            project.ProjectDescription = desc;
            project.ProjectStatus = status; 
            project.startDate= DateTime.Parse(stDate);
            project.EndDate = DateTime.Parse(eDate);
            project.empFK = int.Parse(empRe);
            project.ProjectUrl = url;
            _Con.Projects.Add(project);
            _Con.SaveChanges();
            return "project Added";
        }

        [HttpGet]
        [Route("GetProject")]
        public string GetProject()
        {
            var getData = from em in _Con.Employees 
                          join proj in _Con.Projects on em.Id equals proj.empFK
                          select new {proj.ProjectTitle, em.Name, proj.ProjectDescription,
                          proj.ProjectStatus, proj.startDate, proj.EndDate, proj.ProjectUrl};

            JavaScriptSerializer jsData = new JavaScriptSerializer();
            jsData.MaxJsonLength = int.MaxValue;
            string Val = jsData.Serialize(getData);
            return Val;
        }


        [HttpGet]
        [Route("Delproj/{projNo}")]
        public string Deleteproject(string projNo)
        {
            int Num = int.Parse(projNo);
            Project proj = new Project();
            proj = _Con.Projects.Single(p => p.ID == Num);
            _Con.Projects.Remove(proj);
            _Con.SaveChanges();
            return "deleted project";
        }

        [HttpGet]
        [Route("Editproj/{projNo}/{title}/{desc}/{status}/{stDate}/{eDate}/{empRe}/{url}")]
        public string Editproj(string projNo, string title, string desc, string status, string stDate,
             string eDate, string empRe, string url)
        {
            int Num = int.Parse(projNo); 
            Project proj = new Project();
            proj = _Con.Projects.Single(p => p.ID == Num);
            proj.ProjectTitle = title;
            proj.ProjectDescription = desc;
            proj.ProjectStatus = status;
            proj.startDate = DateTime.Parse(stDate);
            proj.EndDate = DateTime.Parse(eDate); 
            proj.empFK = int.Parse(empRe);
            proj.ProjectUrl = url;
            _Con.Projects.Update(proj);
            _Con.SaveChanges();
            return "updated Project";
        }
    }
}
