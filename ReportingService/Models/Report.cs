using System.ComponentModel.DataAnnotations;

namespace ReportingService.Models
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<ReportDetail> ReportDetails { get; set; }
    }

}
