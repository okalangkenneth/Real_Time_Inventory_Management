using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReportingService.Data;
using ReportingService.Models;

namespace ReportingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportDetailsController : ControllerBase
    {
        private readonly ReportDbContext _context;

        public ReportDetailsController(ReportDbContext context)
        {
            _context = context;
        }

        [HttpGet("{reportId}")]
        public async Task<ActionResult<IEnumerable<ReportDetail>>> GetReportDetailsByReportId(int reportId)
        {
            return await _context.ReportDetails
                                 .Where(rd => rd.ReportId == reportId)
                                 .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ReportDetail>> PostReportDetail(ReportDetail reportDetail)
        {
            _context.ReportDetails.Add(reportDetail);
            await _context.SaveChangesAsync();
            return Created("", reportDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReportDetail(int id, ReportDetail reportDetail)
        {
            if (id != reportDetail.ReportDetailId)
            {
                return BadRequest();
            }
            _context.Entry(reportDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReportDetail(int id)
        {
            var reportDetail = await _context.ReportDetails.FindAsync(id);
            if (reportDetail == null)
            {
                return NotFound();
            }
            _context.ReportDetails.Remove(reportDetail);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}