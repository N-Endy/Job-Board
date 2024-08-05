using JobBoardAPI.Data;
using JobBoardAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobBoardAPI.Controller;

[Route("api/staffs")]
[ApiController]
public class StaffController : ControllerBase
{
    private readonly JobBoardContext _context;

    public StaffController(JobBoardContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
    {
        return await _context.Staffs.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Staff>> GetStaff(int id)
    {
        var staff = await _context.Staffs.SingleOrDefaultAsync(s => s.StaffId == id);

        return staff == null ? NotFound() : staff;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutStaff(int id, Staff staff)
    {
        if (id != staff.StaffId)
            return BadRequest();

        var newStaff = await _context.Staffs.FindAsync(id);
        if (newStaff == null)
            return NotFound();

        newStaff.StaffId = staff.StaffId;
        newStaff.UserName = staff.UserName;
        newStaff.Password =  staff.Password;

        _context.Entry(newStaff).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StaffExists(id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Staff>> PostStaff(Staff staff)
    {
        _context.Staffs.Add(staff);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStaff), new { id = staff.StaffId }, staff);
    }

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