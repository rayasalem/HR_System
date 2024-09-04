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

		[HttpPost]
		[Route("AddEmployee")]
		public string AddEmployee([FromBody] Employee employee)
		{
			_Con.Employees.Add(employee);
			_Con.SaveChanges();
			return "Employee Added";
		}

		[HttpGet]
		[Route("GetEmployees")]
		public string GetEmployees()
		{
			var employeeList = _Con.Employees.Include(e => e.Deps).Include(e => e.pos).Include(e => e.projs).ToList();
			JavaScriptSerializer jsData = new JavaScriptSerializer();
			jsData.MaxJsonLength = int.MaxValue;
			return jsData.Serialize(employeeList);
		}

		[HttpGet]
		[Route("GetEmployee/{id}")]
		public string GetEmployee(int id)
		{
			var employee = _Con.Employees.Include(e => e.Deps).Include(e => e.pos).Include(e => e.projs).SingleOrDefault(e => e.Id == id);
			if (employee == null) return "Employee not found";

			JavaScriptSerializer jsData = new JavaScriptSerializer();
			return jsData.Serialize(employee);
		}

		[HttpPut]
		[Route("EditEmployee/{id}")]
		public string EditEmployee(int id, [FromBody] Employee employeeUpdate)
		{
			var employee = _Con.Employees.Include(e => e.Deps).Include(e => e.pos).Include(e => e.projs).SingleOrDefault(e => e.Id == id);
			if (employee == null) return "Employee not found";

			employee.Name = employeeUpdate.Name;
			employee.Image = employeeUpdate.Image;
			employee.Specialty = employeeUpdate.Specialty;
			employee.Email = employeeUpdate.Email;
			employee.Phone = employeeUpdate.Phone;
			employee.Address = employeeUpdate.Address;
			employee.HireDate = employeeUpdate.HireDate;
			employee.DepRef = employeeUpdate.DepRef;
			employee.PosRef = employeeUpdate.PosRef;
			employee.ProRef = employeeUpdate.ProRef;

			_Con.Employees.Update(employee);
			_Con.SaveChanges();
			return "Employee updated";
		}

		[HttpDelete]
		[Route("DeleteEmployee/{id}")]
		public string DeleteEmployee(int id)
		{
			var employee = _Con.Employees.Include(e => e.Deps).Include(e => e.pos).Include(e => e.projs).SingleOrDefault(e => e.Id == id);
			if (employee == null) return "Employee not found";

			_Con.Employees.Remove(employee);
			_Con.SaveChanges();
			return "Employee deleted";
		}
	}
}
