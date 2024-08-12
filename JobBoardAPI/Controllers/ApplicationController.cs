using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobBoardAPI.Data;
using JobBoardAPI.Models;

namespace JobBoardAPI.Controllers
{
    [Route("api/applications")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly JobBoardContext _context;

        public ApplicationController(JobBoardContext context)
        {
            _context = context;
        }

        // GET: api/Application
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
        {
            return await _context.Applications.ToListAsync();
        }

        // GET: api/Application/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplication(int id)
        {
            var application = await _context.Applications.FindAsync(id);

            return application == null ? NotFound() : application;
        }

        // PUT: api/Application/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplication(int id, Application application)
        {
            if (id != application.ApplicationId)
                return BadRequest();

            var updatedApplication = await _context.Applications.FindAsync(id);
            if (updatedApplication == null)
                return NotFound();

            _context.Entry(application).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(id))
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

        // POST: api/Application
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Application>> PostApplication(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetApplication), new { id = application.ApplicationId }, application);
        }

        // DELETE: api/Application/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null)
                return NotFound();

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.ApplicationId == id);
        }
    }
}
