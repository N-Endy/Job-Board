using API.Data.Contracts.Services;
using API.Data.DTOs;
using API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/jobposts")]
    [ApiController]
    public class JobPostController : ControllerBase
    {
        private readonly IJobPostService _jobPostService;

        public JobPostController(IJobPostService jobPostService)
        {
            _jobPostService = jobPostService;
        }

        // GET: api/jobposts
        [HttpGet]
        public async Task<IActionResult> GetAllJobPostsAsync()
        {
            var jobPosts = await _jobPostService.GetAllJobPostsAsync();
            return Ok(jobPosts);
        }

        // GET: api/jobposts/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetJobPostByIdAsync(int id)
        {
            var jobPost = await _jobPostService.GetJobPostByIdAsync(id);

            if (jobPost is null)
            {
                return NotFound();
            }

            return Ok(jobPost);
        }

        // POST: api/jobposts
        [HttpPost]
        public async Task<IActionResult> AddJobPostAsync (JobPostDto jobPost)
        {
            var newJobPost = new JobPost
            {
                Title = jobPost.Title,
                Description = jobPost.Description,
                StaffId = jobPost.StaffId,
                StaffFullName = jobPost.StaffFullName
            };

            var addedJobPost = await _jobPostService.AddJobPostAsync(newJobPost);

            if (addedJobPost == null || addedJobPost.JobPostId == 0)
            {
                return BadRequest("Failed to create job post.");
            }

            return Ok(addedJobPost);
        }

        // DELETE: api/jobposts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobPost(int id)
        {
            var existingJobPost = await _jobPostService.GetJobPostByIdAsync(id);

            if (existingJobPost == null)
            {
                return NotFound();
            }

            _ = await _jobPostService.DeleteJobPostAsync(id);
            return NoContent();
        }
    }
}