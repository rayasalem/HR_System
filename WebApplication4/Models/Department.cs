using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models
{
    public class Department
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Display(Name = "Department Name")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? DepartmentName { get; set; }

        [Display(Name = "NumberOfEmployees")]
        [Column(TypeName = "int")]
        public  int NumberOfEmployees { get; set; }

        [Display(Name = "Head of Department")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? DepartmentHead { get; set; }

        [Display(Name = "Location")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Location { get; set; }

        [Display(Name = "Budget")]
        [Column(TypeName = "int")]
        public int? Budget { get; set; }


    }
}
