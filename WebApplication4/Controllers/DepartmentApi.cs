using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using WebApplication4.DSConn;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentApi : ControllerBase
    {
        public readonly DBContext _Con;
        public DepartmentApi(DBContext con)
        {
            _Con = con;
        }

        [HttpGet]
        [Route("AddDep/{DepName}/{NoEmp}/{Head}/{location}/{buget}")]
        public string AddDepartment(string DepName, string NoEmp, string Head,
                  string location, string buget)
        {
            Department ObjDep = new Department();
            ObjDep.DepartmentName = DepName;
            ObjDep.NumberOfEmployees = int.Parse(NoEmp);
            ObjDep.DepartmentHead = Head;
            ObjDep.Location = location;
            ObjDep.Budget = int.Parse(buget);
            _Con.Departments.Add(ObjDep);
            _Con.SaveChanges();
            return "Department Added";
        }


        [HttpGet]
        [Route("GetDep")]
        public string GetDepartment()
        {

            var ObjGet = _Con.Departments.ToList();
            JavaScriptSerializer jsData = new JavaScriptSerializer();
            jsData.MaxJsonLength = int.MaxValue;
            string Val = jsData.Serialize(ObjGet);
            return Val;
        }

        [HttpGet]
        [Route("DelDep/{DepNo}")]
        public string DeleteDep(string DepNo)
        {
            int Num = int.Parse(DepNo);
            Department ObjDep = new Department();
            ObjDep = _Con.Departments.Single(d => d.ID == Num);
            _Con.Departments.Remove(ObjDep);
            _Con.SaveChanges();
            return "deleted Department";
        }

        [HttpGet]
        [Route("EditDep/{DepNo}/{DepName}/{NoEmp}/{Head}/{location}/{buget}")]
        public string EditDep(string DepNo, string DepName, string NoEmp,
            string Head, string location, string buget)
        {
            int Num = int.Parse(DepNo);
            Department ObjDep = new Department();
            ObjDep = _Con.Departments.Single(d => d.ID == Num);
            ObjDep.DepartmentName = DepName;
            ObjDep.NumberOfEmployees = int.Parse(NoEmp);
            ObjDep.DepartmentHead = Head;
            ObjDep.Location = location;
            ObjDep.Budget = int.Parse(buget);
            _Con.Departments.Update(ObjDep);
            _Con.SaveChanges();
            return "updated Department";
        }
    }
}
