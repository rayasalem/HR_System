using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models {
    public class Employee
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Name { get; set; }


        [Display(Name = "Image")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Image { get; set; }


        [Display(Name = "Specialty")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Specialty { get; set; }

        [Display(Name = "Email")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Email { get; set; }

        [Display(Name = "Phone")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Phone { get; set; }

        [Display(Name = "Address")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Address { get; set; }

        [Display(Name = "HireDate")]
        [Column(TypeName = "datetime")]
        public DateTime? HireDate { get; set; }


        [ForeignKey("DepRef")]
        public int DepRef { get; set; }
        public Department? Deps { get; set; }


    }
}
