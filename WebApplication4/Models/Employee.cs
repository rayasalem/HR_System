using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Models {
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [Url]
        public string? Image { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Specialty { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        public DateTime? HireDate { get; set; }


        [ForeignKey("DepRef")]
        public int DepRef { get; set; }
        public Department? Deps { get; set; }


        [ForeignKey("PosRef")]
        public int PosRef { get; set; }
        public Position? pos { get; set; }
        [ForeignKey("ProRef")]
        public int ProRef { get; set; }
        public Project? projs { get; set; }


    }
}
