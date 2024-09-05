using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Project
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }


        [Display(Name = "Project Title")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ProjectTitle { get; set; }

        [Display(Name = "Project Description")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ProjectDescription { get; set; }

        [Display(Name = "Project Status")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ProjectStatus { get; set; }

        [Display(Name = "ProjectUrl")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? ProjectUrl { get; set; }

        [Display(Name = "Date")]
        [Column(TypeName = "datetime")]
        public DateTime? startDate { get; set; }

        [Display(Name = "EndDate")]
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }


        [ForeignKey("EmpRef")]
        public int EmpRef { get; set; }
        public Employee? EmpRef { get; set; }

    }
}
