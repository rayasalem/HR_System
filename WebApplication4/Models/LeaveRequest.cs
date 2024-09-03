using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class LeaveRequest
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Display(Name = "NoRequest")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? NoRequest { get; set; }


        [Display(Name = "Type Request")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Type { get; set; }


        [Display(Name = "StartDate")]
        [Column(TypeName = "date")]
        public DateOnly StartDate { get; set; }


        [Display(Name = "ExpiryDate")]
        [Column(TypeName = "date")]
        public DateOnly ExpiryDate { get; set; }


        [Display(Name = "Message Request")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Message { get; set; }


        [Display(Name = "State Request")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? State { get; set; }

        [ForeignKey("EmpRef")]
        public int EmpRef { get; set; }
        public Employee? emps { get; set; }
    }
}
