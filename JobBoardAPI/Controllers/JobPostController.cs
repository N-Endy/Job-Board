using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobBoardAPI.Data;
using JobBoardAPI.Models;

namespace JobBoardAPI.Controllers
{
    [Route("api/jobposts")]
    [ApiController]
    public class JobPostController : ControllerBase
    {
        private readonly JobBoardContext _context;

        public JobPostController(JobBoardContext context)
        {
            _context = context;
        }

        // GET: api/JobPost
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobPost>>> GetJobPosts()
        {
            return await _context.JobPosts
                .Include(a => a.Applications)
                .ToListAsync();
        }

        // GET: api/JobPost/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobPost>> GetJobPost(int id)
        {
            var jobPost = await _context.JobPosts.FindAsync(id);

            return jobPost == null ? NotFound() : jobPost;
        }

        // PUT: api/JobPost/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobPost(int id, JobPost jobPost)
        {
            if (id != jobPost.JobPostId)
                return BadRequest();

            var newJobPost = await _context.JobPosts.FindAsync(id);
            if (newJobPost == null)
                return NotFound();

            newJobPost.Title = jobPost.Title;
            newJobPost.Description = jobPost.Description;
            newJobPost.StaffId = jobPost.StaffId;
            newJobPost.Staff = jobPost.Staff;

            _context.Entry(jobPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobPostExists(id))
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

        // POST: api/JobPost
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobPost>> PostJobPost(JobPost jobPost)
        {
            _context.JobPosts.Add(jobPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJobPost), new { id = jobPost.JobPostId }, jobPost);
        }

        // DELETE: api/JobPost/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobPost(int id)
        {
            var jobPost = await _context.JobPosts.FindAsync(id);
            if (jobPost == null)
                return NotFound();

            _context.JobPosts.Remove(jobPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobPostExists(int id)
        {
            return _context.JobPosts.Any(e => e.JobPostId == id);
        }
    }
}
