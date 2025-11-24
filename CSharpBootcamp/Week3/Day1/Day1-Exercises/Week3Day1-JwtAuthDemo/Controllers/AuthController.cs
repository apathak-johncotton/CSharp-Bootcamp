using Microsoft.AspNetCore.Mvc;
using Week3Day1_JwtAuthDemo.Models;
using Week3Day1_JwtAuthDemo.Services;

namespace Week3Day1_JwtAuthDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthRequestDto request)
        {
            var success = await _authService.RegisterAsync(request);
            if (!success)
                return BadRequest("User with this email already exists");

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login(AuthRequestDto request)
        {
            var authResponse = await _authService.LoginAsync(request);
            if (authResponse is null)
                return Unauthorized("Invalid email or password");

            return Ok(authResponse);
        }
    }
}
