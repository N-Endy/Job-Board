using API.Data.Contracts.Services;
using API.Data.DTOs;
using API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/staffs")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        // GET: api/staffs
        [HttpGet]
        public async Task<IActionResult> GetAllStaffAsync()
        {
            var staffs = await _staffService.GetAllStaffAsync();
            return Ok(staffs);
        }

        // GET: api/staffs/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStaffByIdAsync(int id)
        {
            var staff = await _staffService.GetStaffByIdAsync(id);

            if (staff is null)
            {
                return NotFound();
            }

            return Ok(staff);
        }

        // GET: api/staffs/Endy
        [HttpGet("{username}")]
        public async Task<IActionResult> GetStaffByUsernameAsync(string username)
        {
            var staff = await _staffService.GetStaffByUsernameAsync(username);

            if (staff is null)
            {
                return NotFound();
            }

            return Ok(staff);
        }
        
        // GET: api/staffs/{username}
        [HttpGet("find/{username}")]
        public async Task<IActionResult> GetStaffLoginDetails(string username)
        {
            var loginDetails = await _staffService.GetStaffLoginDetailsAsync(username);
            
            if (loginDetails is null)
            {
                return NotFound();
            }

            return Ok(loginDetails);
        }

        // POST: api/staffs
        [HttpPost]
        public async Task<IActionResult> AddStaffAsync(StaffDto staffDto)
        {
            // Check if the username already exists
            var existingStaff = await _staffService.GetStaffByUsernameAsync(staffDto.Username);

            if (existingStaff != null)
            {
                return Conflict("Username already exists");
            }

            var newStaff = new Staff
            {
                Username = staffDto.Username,
                Password = staffDto.Password,
                FullName = staffDto.FullName,
                UserType = staffDto.UserType
            };

            var addedStaff = await _staffService.AddStaffAsync(newStaff);

            if (addedStaff == null || addedStaff.StaffId == 0)
            {
                return BadRequest("Failed to create staff or generate valid ID.");
            }

            // Manually generate URL for verification
            // var url = Url.Action(nameof(GetStaffByIdAsync), new { id = addedStaff.StaffId });

            // if (string.IsNullOrEmpty(url))
            // {
            //     return BadRequest("Could not generate URL for the created resource.");
            // }

            //return CreatedAtAction(nameof(GetStaffByIdAsync), new { id = addedStaff.StaffId }, addedStaff);
            //return Ok(new { id = addedStaff.StaffId });
            return Ok(addedStaff);
        }

        // DELETE: api/staffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffAsync(int id)
        {
            var existingStaff = await _staffService.GetStaffByIdAsync(id);

            if (existingStaff == null)
                return NotFound();

            _ = await _staffService.DeleteStaffAsync(id);
            return NoContent();
        }
    }
}