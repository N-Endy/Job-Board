using API.Data.Contracts.Services;
using API.Data.DTOs;
using API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/applicants")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        // GET: api/applicants
        [HttpGet]
        public async Task<IActionResult> GetAllApplicantsAsync()
        {
            var applicants = await _applicantService.GetAllApplicantsAsync();
            return Ok(applicants);
        }

        // GET: api/applicants/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetApplicantByIdAsync(int id)
        {
            var applicant = await _applicantService.GetApplicantByIdAsync(id);

            if (applicant is null)
            {
                return NotFound();
            }

            return Ok(applicant);
        }

        // GET: api/applicants/find/{fullName}
        [HttpGet("find/{fullName}")]
        public async Task<IActionResult> GetApplicantByFullNameAsync(string fullName)
        {
            var applicant = await _applicantService.GetApplicantByFullNameAsync(fullName);

            if (applicant is null)
            {
                return NotFound();
            }

            return Ok(applicant);
        }

        // POST: api/applicants
        [HttpPost]
        public async Task<IActionResult> AddApplicantAsync(ApplicantDto applicantDto)
        {
            // Check if the username already exists
            // var existingApplicant = await _applicantService.GetApplicantByFullNameAsync(applicantDto.FullName);

            // if (existingApplicant != null)
            // {
            //     return Conflict("Applicant already exists");
            // }

            var newApplicant = new Applicant
            {
                FullName = applicantDto.FullName,
            };

            var createdApplicant = await _applicantService.AddApplicantAsync(newApplicant);

            if (createdApplicant == null || createdApplicant.ApplicantId == 0)
            {
                return BadRequest("Failed to create applicant.");
            }

            return Ok(createdApplicant);
            // return CreatedAtAction(nameof(GetApplicantByIdAsync), new { id = createdApplicant.ApplicantId }, createdApplicant);
        }

        // DELETE: api/applicants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicantAsync(int id)
        {
            var existingApplicant = await _applicantService.GetApplicantByIdAsync(id);

            if (existingApplicant == null)
                return NotFound();

            _ = await _applicantService.DeleteApplicantAsync(id);
            return NoContent();
        }
    }
}