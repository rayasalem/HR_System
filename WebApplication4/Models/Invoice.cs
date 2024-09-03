using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{

    public class Invoice
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Display(Name = "Invoice Name")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? InvoiceName { get; set; }


        [Display(Name = "Amount")]
        [Column(TypeName = "decimal (18, 0)")]
        public decimal? Amount { get; set; }

        [Display(Name = "Invoice Date")]
        [Column(TypeName = "date")]
        public DateOnly? InvoiceDate { get; set; }


        [Display(Name = "Invoice Due")]
        [Column(TypeName = "date")]
        public DateOnly? InvoiceDue { get; set; }

        [Display(Name = "Invoice Description")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? InvoiceDescription { get; set; }

        [Required]
        [Display(Name = "Status")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Status { get; set; }


        [ForeignKey("EmpRef")]
        public int EmpRef { get; set; }
        public Employee? emps { get; set; }
    }
}
