using API.Data.Contracts.Services;
using API.Data.DTOs;
using API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/applications")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // GET: /api/applications
        [HttpGet]
        public async Task<IActionResult> GetAllApplicationsAsync()
        {
            var applications = await _applicationService.GetAllApplicationsAsync();
            return Ok(applications);
        }

        // GET: /api/applications/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetApplicationByIdAsync(int id)
        {
            var application = await _applicationService.GetApplicationByIdAsync(id);

            if (application is null)
            {
                return NotFound();
            }

            return Ok(application);
        }

        // POST: /api/applications
        [HttpPost]
        public async Task<IActionResult> AddApplicationAsync(ApplicationDto application)
        {
            var newApplication = new Application
            {
                JobPostId = application.JobPostId,
                JobTitle = application.JobTitle,
                ApplicantId = application.ApplicantId,
                StaffId = application.StaffId,
                ApplicantFullName = application.ApplicantFullName,
                ApplicationStatus = application.ApplicationStatus,
                AssignedStaffName = application.AssignedStaffName
            };

            var addedApplication = await _applicationService.AddApplicationAsync(newApplication);

            if (addedApplication == null || addedApplication.ApplicationId == 0)
            {
                return BadRequest("Failed to create application.");
            }

            return Ok(addedApplication);

            // return CreatedAtAction(nameof(GetApplicationByIdAsync), new { id = addedApplication.ApplicationId }, addedApplication);
        }

        // DELETE: /api/applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationAsync(int id)
        {
            var existingApplication = await _applicationService.GetApplicationByIdAsync(id);

            if (existingApplication == null)
                return NotFound();

            _ = await _applicationService.DeleteApplicationAsync(id);
            return NoContent();
        }
    }
}