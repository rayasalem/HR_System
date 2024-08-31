using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Contract
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Display(Name = "Contract Type")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ContractType { get; set; }

        [Display(Name = "Position")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Position { get; set; }


        [Display(Name = "StartDate")]
        [Column(TypeName = "date")]
        public DateOnly? StartDate { get; set; }


        [Display(Name = "End Date")]
        [Column(TypeName = "date")]
        public DateOnly? EndDate { get; set; }
    }
}
