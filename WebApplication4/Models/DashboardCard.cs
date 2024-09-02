using System.ComponentModel.DataAnnotations;


    public class DashboardCard
    {
        [Key]
        public int CardId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Value { get; set; }

        [Required]
        [MaxLength(50)]
        public string BgColor { get; set; }

        [Required]
        [MaxLength(100)]
        public string IconName { get; set; } // Store the icon name or path
    }