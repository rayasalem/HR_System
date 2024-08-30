using System;
using System.ComponentModel.DataAnnotations;


    public class Employee
    {
        [Key] 
        public int Id { get; set; }

        [Required] 
        [MaxLength(100)] 
        public string? Name { get; set; }

        [Required] 
        [Url] 
        public string ?Image { get; set; }

        [Required]
        [MaxLength(100)] 
        public string? Specialty { get; set; }

        [EmailAddress] 
        public string ?Email { get; set; }

        [Phone]
        public string? Phone { get; set; }

        [MaxLength(200)] 
        public string? Address { get; set; }

        public DateTime? HireDate { get; set; } 
    }
