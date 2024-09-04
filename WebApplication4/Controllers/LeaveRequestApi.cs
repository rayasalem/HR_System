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
        private readonly DBContext _Con;

        public LeaveRequestApi(DBContext con)
        {
            _Con = con;
        }

        [HttpPost]
        [Route("AddLeaveRequest")]
        public string AddLeaveRequest(string NoRequest, string Type, string StartDate, string ExpiryDate,
                                      string Message, int EmpRef)
        {
            var newLeaveRequest = new LeaveRequest
            {
                NoRequest = NoRequest,
                Type = Type,
                StartDate = DateTime.Parse(StartDate),
                ExpiryDate = DateTime.Parse(ExpiryDate),
                Message = Message,
                State = "Pending",
                EmpRef = EmpRef
            };

            _Con.LeaveRequests.Add(newLeaveRequest);
            _Con.SaveChanges();
            return "Leave Request Added";
        }

        [HttpGet]
        [Route("GetLeaveRequests")]
        public string GetLeaveRequests()
        {
            var leaveRequests = from lr in _Con.LeaveRequests
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

            var jsSerializer = new JavaScriptSerializer
            {
                MaxJsonLength = int.MaxValue
            };

            return jsSerializer.Serialize(leaveRequests);
        }

        [HttpPost]
        [Route("UpdateLeaveRequestState")]
        public string UpdateLeaveRequestState(int id, string State)
        {
            var leaveRequest = _Con.LeaveRequests.SingleOrDefault(lr => lr.RequestId == id);
            if (leaveRequest == null)
            {
                return "Leave Request not found";
            }

            if (State == "Approved" || State == "Rejected")
            {
                leaveRequest.State = State;
                _Con.LeaveRequests.Update(leaveRequest);
                _Con.SaveChanges();
                return $"Leave Request {State}";
            }
            else
            {
                return "Invalid state. State must be 'Approved' or 'Rejected'.";
            }
        }

        [HttpDelete]
        [Route("DeleteLeaveRequest/{id}")]
        public string DeleteLeaveRequest(int id)
        {
            var leaveRequest = _Con.LeaveRequests.SingleOrDefault(lr => lr.RequestId == id);
            if (leaveRequest == null)
            {
                return "Leave Request not found";
            }

            _Con.LeaveRequests.Remove(leaveRequest);
            _Con.SaveChanges();
            return "Leave Request Deleted";
        }
    }
}
