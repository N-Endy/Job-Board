using API.Data.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // GET: api/auth/login
        [HttpGet("login")]
        public async Task<IActionResult> LoginAsync(string username, string password)
        {
            var loginDetails = await _authService.GetStaffByUsernameAsync(username);

            if (loginDetails is null)
            {
                return Unauthorized();
            }

            // TODO: Implement password hashing and comparison
            if (loginDetails.Password == password)
            {
                return Ok(loginDetails);
            }

            return Unauthorized();
        }

        // POST: api/auth/login
    }
}