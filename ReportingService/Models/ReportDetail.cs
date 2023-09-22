using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReportingService.Models
{
    public class ReportDetail
    {
        [Key]
        public int ReportDetailId { get; set; }

        [ForeignKey("Report")]
        public int ReportId { get; set; }

        public Report Report { get; set; }

        [Required]
        public string Data { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } // Table, Chart, etc.
    }
}
