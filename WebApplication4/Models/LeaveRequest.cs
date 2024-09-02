using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class LeaveRequest
{
    [Key]
    public int RequestId { get; set; }

    [Required]
    [MaxLength(10)]
    public string NoRequest { get; set; }

    [Required]
    [MaxLength(20)]
    public string EmpId { get; set; }

    [Required]
    [MaxLength(100)]
    public string EmpName { get; set; }

    [Required]
    [MaxLength(50)]
    public string Type { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime ExpiryDate { get; set; }

    [MaxLength(500)]
    public string Message { get; set; }

    [Required]
    [MaxLength(20)]
    public string State { get; set; }

    [ForeignKey("EmpRef")]
    public int EmpRef { get; set; }
    public Employee? emps { get; set; }
}
