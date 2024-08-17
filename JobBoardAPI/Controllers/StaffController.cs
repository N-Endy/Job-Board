using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobBoardAPI.Data;
using JobBoardAPI.Models;

namespace JobBoardAPI.Controllers
{
    // change one staff
    /*[Route("api")]
    [ApiController]*/
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly JobBoardContext _context;

        public StaffController(JobBoardContext context)
        {
            _context = context;
        }

       //  GET: api/Staff/{username}
       // change two templates
        [HttpGet("find/{username}", Name = "Login")]
        public async Task<ActionResult<Staff>> GetStaffLogin(string username)
        {
            var staff = await _context.Staffs.FirstOrDefaultAsync(s => s.UserName == username);
            return staff == null ? NotFound() : staff;

        }

        // GET: api/Staff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
        {
            return await _context.Staffs
                .Include(s => s.JobPosts)
                .ToListAsync();
        }

        // GET: api/Staff/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);

            return staff == null ? NotFound() : staff;
        }

        // PUT: api/Staff/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff staff)
        {
            if (id != staff.StaffId)
                return BadRequest();

            var newStaff = await _context.Staffs.FindAsync(id);
            if (newStaff == null)
                return NotFound();

            newStaff.UserName = staff.UserName;
            newStaff.Password =  staff.Password;
            newStaff.FullName = staff.FullName;

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
                    return NotFound();
                else
                    return StatusCode(500, "A concurrency error occurred. Please try again.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

            return NoContent();
        }

        // POST: api/Staff
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStaff), new { id = staff.StaffId }, staff);
        }

        // DELETE: api/Staff/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
                return NotFound();

            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.StaffId == id);
        }
    }
}
