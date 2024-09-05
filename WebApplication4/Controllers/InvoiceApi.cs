using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using WebApplication4.DSConn;
using WebApplication4.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceApi : ControllerBase
    {
        public readonly DBContext _Con;

        public InvoiceApi(DBContext con)
        {
            _Con = con;
        }

        [HttpGet]
        [Route("AddInvoice/{Name}/{Amount}/{InvoiceDate}/{InvoiceDue}/{Description}/{Status}/{EmpRef}")]
        public string AddInvoice(string Name, string Amount, string InvoiceDate, string InvoiceDue,
                                 string Description, string Status, string EmpRef)
        {
            Invoice ObjInv = new Invoice
            {
                InvoiceName = Name,
                Amount = decimal.Parse(Amount),
                InvoiceDate = DateTime.Parse(InvoiceDate),
                InvoiceDue = DateTime.Parse(InvoiceDue),
                InvoiceDescription = Description,
                Status = Status,
                EmpRef = int.Parse(EmpRef)
            };

            _Con.Invoices.Add(ObjInv);
            _Con.SaveChanges();
            return "Invoice Added";
        }

        [HttpGet]
        [Route("GetInvoices")]
        public string GetInvoices()
        {
            var getData = from inv in _Con.Invoices
                          join emp in _Con.Employees on inv.EmpRef equals emp.Id
                          select new
                          {
                              inv.InvoiceName,
                              inv.Amount,
                              inv.InvoiceDate,
                              inv.InvoiceDue,
                              inv.InvoiceDescription,
                              inv.Status,
                              EmployeeName = emp.Name
                          };

            JavaScriptSerializer jsData = new JavaScriptSerializer
            {
                MaxJsonLength = int.MaxValue
            };
            return jsData.Serialize(getData);
        }

        [HttpGet]
        [Route("EditInvoice/{InvoiceNo}/{Name}/{Amount}/{InvoiceDate}/{InvoiceDue}/{Description}/{Status}/{EmpRef}")]
        public string EditInvoice(string InvoiceNo, string Name, string Amount, string InvoiceDate,
                                  string InvoiceDue, string Description, string Status, string EmpRef)
        {
            int Num = int.Parse(InvoiceNo);
            Invoice ObjInv = _Con.Invoices.Single(i => i.ID == Num);
            ObjInv.InvoiceName = Name;
            ObjInv.Amount = decimal.Parse(Amount);
            ObjInv.InvoiceDate = DateTime.Parse(InvoiceDate);
            ObjInv.InvoiceDue = DateTime.Parse(InvoiceDue);
            ObjInv.InvoiceDescription = Description;
            ObjInv.Status = Status;
            ObjInv.EmpRef = int.Parse(EmpRef);

            _Con.Invoices.Update(ObjInv);
            _Con.SaveChanges();
            return "Invoice updated";
        }

        [HttpDelete]
        [Route("DeleteInvoice/{id}")]
        public string DeleteInvoice(int id)
        {
            var invoice = _Con.Invoices.Include(i => i.emps).SingleOrDefault(i => i.ID == id);
            if (invoice == null) return "Invoice not found";

            _Con.Invoices.Remove(invoice);
            _Con.SaveChanges();
            return "Invoice deleted";
        }
    }
}
