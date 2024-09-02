using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime? InvoiceDate { get; set; }

        [Required]
        public DateTime ?InvoiceDue { get; set; }

        [MaxLength(500)]
        public string ?Description { get; set; }

    [Required]
    [MaxLength(20)]
    public string? Status { get; set; }
    [ForeignKey("EmpRef")]
    public int EmpRef { get; set; }
    public Employee? emps { get; set; }
}