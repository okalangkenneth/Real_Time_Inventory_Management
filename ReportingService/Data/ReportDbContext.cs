using Microsoft.EntityFrameworkCore;
using ReportingService.Models;

namespace ReportingService.Data
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options)
        {
        }

        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportDetail> ReportDetails { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Reports
            modelBuilder.Entity<Report>().HasData(
                new Report { ReportId = 1, Name = "Monthly Sales", Description = "Sales data for the month", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new Report { ReportId = 2, Name = "Quarterly Revenue", Description = "Revenue data for the quarter", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
            );

            // Seed ReportDetails
            modelBuilder.Entity<ReportDetail>().HasData(
                new ReportDetail { ReportDetailId = 1, ReportId = 1, Data = "Some data for Monthly Sales", Type = "Table" },
                new ReportDetail { ReportDetailId = 2, ReportId = 1, Data = "Some more data for Monthly Sales", Type = "Chart" },
                new ReportDetail { ReportDetailId = 3, ReportId = 2, Data = "Some data for Quarterly Revenue", Type = "Table" }
            );

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "john_doe", Email = "john.doe@example.com" },
                new User { UserId = 2, Username = "jane_doe", Email = "jane.doe@example.com" }
            );
        }

    }
}
