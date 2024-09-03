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
    }
}
