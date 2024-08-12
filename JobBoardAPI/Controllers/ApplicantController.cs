using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobBoardAPI.Data;
using JobBoardAPI.Models;

namespace JobBoardAPI.Controllers
{
    [Route("api/applicant")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly JobBoardContext _context;

        public ApplicantController(JobBoardContext context)
        {
            _context = context;
        }

        // GET: api/Applicant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Applicant>>> GetApplicants()
        {
            return await _context.Applicants
                .Include(x => x.Applications)
                .ToListAsync();
        }

        // GET: api/Applicant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Applicant>> GetApplicant(int id)
        {
            var applicant = await _context.Applicants.FindAsync(id);

            return applicant == null ? NotFound() : applicant;
        }

        // PUT: api/Applicant/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplicant(int id, Applicant applicant)
        {
            if (id != applicant.ApplicantId)
                return BadRequest();

            var updatedApplicant = await _context.Applicants.FindAsync(id);
            if (updatedApplicant == null)
                return NotFound();

            updatedApplicant.FullName = applicant.FullName;

            _context.Entry(applicant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicantExists(id))
                    return NotFound();
                else
                    return StatusCode(500, "A concurrency error occurred. Please try again");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

            return NoContent();
        }

        // POST: api/Applicant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Applicant>> PostApplicant(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetApplicant), new { id = applicant.ApplicantId }, applicant);
        }

        // DELETE: api/Applicant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicant(int id)
        {
            var applicant = await _context.Applicants.FindAsync(id);
            if (applicant == null)
                return NotFound();

            _context.Applicants.Remove(applicant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicantExists(int id)
        {
            return _context.Applicants.Any(e => e.ApplicantId == id);
        }
    }
}
