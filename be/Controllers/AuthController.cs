using be.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!loginDTO.UserName!.Equals("admin") && !loginDTO.Password!.Equals("admin123"))
            {
                return Unauthorized();
            }   
            return Ok();
        }

        [HttpPost("signup")]
        public IActionResult Register([FromBody] SignUpDTO signUpDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok();

        }
    }
}
