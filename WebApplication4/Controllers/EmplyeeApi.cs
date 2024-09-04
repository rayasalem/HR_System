using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using WebApplication4.DSConn;
using WebApplication4.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApi : ControllerBase
    {
        public readonly DBContext _Con;

        public EmployeeApi(DBContext con)
        {
            _Con = con;
        }

        [HttpGet]
        [Route("AddEmp/{Name}/{Img}/{spec}/{email}/{phone}/{address}/{HDate}/{DepRef}/{ProRef}")]
        public string AddEmployee(string Name, string Img, string spec, string email, string phone,
            string address, string HDate, string DepRef, string pos, string ProRef)
        {
            Employee ObjEmp = new Employee();
            ObjEmp.Name = Name;
            ObjEmp.Image = Img;
            ObjEmp.Specialty = spec;
            ObjEmp.Email = email;
            ObjEmp.Phone = phone;
            ObjEmp.Address = address;
            ObjEmp.HireDate = DateTime.Parse(HDate);
            ObjEmp.DepRef = int.Parse(DepRef);
            ObjEmp.ProRef = int.Parse(ProRef);
            _Con.Employees.Add(ObjEmp);
            _Con.SaveChanges();
            return "Employee Added";
        }

        [HttpGet]
        [Route("GetEmployees")]
        public string GetEmployees()
        {
            var getData = from em in _Con.Employees
                          join dep in _Con.Departments on em.DepRef equals dep.ID
                          join proj in _Con.Projects on em.ProRef equals proj.ID
                          select new {em.Name, dep.DepartmentName, proj.ProjectTitle,
                              em.Image, em.Specialty, em.Address, em.Email, em.Phone, em.HireDate};

            JavaScriptSerializer jsData = new JavaScriptSerializer();
            jsData.MaxJsonLength = int.MaxValue;
            string Val = jsData.Serialize(getData);
            return Val;
        }

        [HttpGet]
        [Route("EditEmp/{EmpNo}/{Name}/{Img}/{spec}/{email}/{phone}/{address}/{HDate}/{DepRef}/{ProRef}")]
        public string EditEmployee(string EmpNo, string Name, string Img, string spec, string email, string phone,
            string address, string HDate, string DepRef, string PosRef, string ProRef)
        {
            int Num = int.Parse(EmpNo);
            Employee ObjEmp = new Employee();
            ObjEmp = _Con.Employees.Single(e => e.Id == Num);
            ObjEmp.Name = Name;
            ObjEmp.Image = Img;
            ObjEmp.Specialty = spec;
            ObjEmp.Email = email;
            ObjEmp.Phone = phone;
            ObjEmp.Address = address;
            ObjEmp.HireDate = DateTime.Parse(HDate);
            ObjEmp.DepRef = int.Parse(DepRef);
            ObjEmp.ProRef = int.Parse(ProRef);

            _Con.Employees.Update(ObjEmp);
            _Con.SaveChanges();
            return "Employee updated";
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public string DeleteEmployee(int id)
        {
            var employee = _Con.Employees.Include(e => e.Deps).Include(e => e.projs).SingleOrDefault(e => e.Id == id);
            if (employee == null) return "Employee not found";

            _Con.Employees.Remove(employee);
            _Con.SaveChanges();
            return "Employee deleted";
        }
    }
}
