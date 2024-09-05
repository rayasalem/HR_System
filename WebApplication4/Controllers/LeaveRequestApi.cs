using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using WebApplication4.DSConn;
using WebApplication4.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestApi : ControllerBase
    {
        public readonly DBContext _Con;

        public LeaveRequestApi(DBContext con)
        {
            _Con = con;
        }

        [HttpGet]
        [Route("AddLeaveRequest/{NoRequest}/{Type}/{StartDate}/{ExpiryDate}/{Message}/{EmpRef}")]
        public string AddLeaveRequest(string NoRequest, string Type, string StartDate, string ExpiryDate, string Message, string EmpRef)
        {
            LeaveRequest ObjLeaveRequest = new LeaveRequest();
            ObjLeaveRequest.NoRequest = NoRequest;
            ObjLeaveRequest.Type = Type;
            ObjLeaveRequest.StartDate = DateTime.Parse(StartDate);
            ObjLeaveRequest.ExpiryDate = DateTime.Parse(ExpiryDate);
            ObjLeaveRequest.Message = Message;
            ObjLeaveRequest.State = "Pending";
            ObjLeaveRequest.EmpRef = int.Parse(EmpRef);

            _Con.LeaveRequests.Add(ObjLeaveRequest);
            _Con.SaveChanges();
            return "Leave Request Added";
        }

        [HttpGet]
        [Route("GetLeaveRequests")]
        public string GetLeaveRequests()
        {
            var getData = from lr in _Con.LeaveRequests
                          join emp in _Con.Employees on lr.EmpRef equals emp.Id
                          select new
                          {
                              lr.NoRequest,
                              lr.Type,
                              lr.StartDate,
                              lr.ExpiryDate,
                              lr.Message,
                              lr.State,
                              EmployeeName = emp.Name
                          };

            JavaScriptSerializer jsData = new JavaScriptSerializer();
            jsData.MaxJsonLength = int.MaxValue;
            string Val = jsData.Serialize(getData);
            return Val;
        }

        [HttpGet]
        [Route("EditLeaveRequest/{RequestId}/{NoRequest}/{Type}/{StartDate}/{ExpiryDate}/{Message}/{EmpRef}")]
        public string EditLeaveRequest(string RequestId, string NoRequest, string Type, string StartDate, string ExpiryDate, string Message, string EmpRef)
        {
            int ReqId = int.Parse(RequestId);
            LeaveRequest ObjLeaveRequest = _Con.LeaveRequests.Single(e => e.RequestId == ReqId);
            ObjLeaveRequest.NoRequest = NoRequest;
            ObjLeaveRequest.Type = Type;
            ObjLeaveRequest.StartDate = DateTime.Parse(StartDate);
            ObjLeaveRequest.ExpiryDate = DateTime.Parse(ExpiryDate);
            ObjLeaveRequest.Message = Message;
            ObjLeaveRequest.EmpRef = int.Parse(EmpRef);

            _Con.LeaveRequests.Update(ObjLeaveRequest);
            _Con.SaveChanges();
            return "Leave Request Updated";
        }

        [HttpDelete]
        [Route("DeleteLeaveRequest/{id}")]
        public string DeleteLeaveRequest(string id)
        {
            int ReqId = int.Parse(id);
            LeaveRequest ObjLeaveRequest = _Con.LeaveRequests.Single(e => e.RequestId == ReqId);
            _Con.LeaveRequests.Remove(ObjLeaveRequest);
            _Con.SaveChanges();
            return "Leave Request Deleted";
        }
    }
}
