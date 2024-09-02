using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Position
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Display(Name = "Position Title")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? PositionTitle { get; set; }

        [Display(Name = "Position Description")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? PositionDescription { get; set; }
    }
}
