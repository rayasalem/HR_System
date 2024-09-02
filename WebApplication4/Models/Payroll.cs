using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class Payroll
    {
        [Key]
        public int PayrollId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string ?Address { get; set; }

        [Required]
        [MaxLength(250)]
        public string ?Avatar { get; set; }

        [Required]
        [MaxLength(100)]
        public string ?Position { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Salary { get; set; }

    [Required]
    public DateTime AppliedDate { get; set; }
    [ForeignKey("EmpRef")]
    public int EmpRef { get; set; }
    public Employee? emps { get; set; }
}

