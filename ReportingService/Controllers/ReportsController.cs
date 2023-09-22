using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReportingService.Data;
using ReportingService.Models;

namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly ReportDbContext _context;

        public ReportsController(ReportDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetReports()
        {
            return await _context.Reports.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> GetReport(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return report;
        }

        [HttpPost]
        public async Task<ActionResult<Report>> PostReport(Report report)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetReport), new { id = report.ReportId }, report);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReport(int id, Report report)
        {
            if (id != report.ReportId)
            {
                return BadRequest();
            }
            _context.Entry(report).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

   
}

