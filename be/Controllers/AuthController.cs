using be.DTOs;
using be.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login([FromQuery] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var user = await _authService.LoginUser(loginDTO);
                return Ok(user);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost("signup")]
        public async Task<IActionResult> Register([FromBody] SignUpDTO signUpDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                await _authService.RegisterUser(signUpDTO);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
