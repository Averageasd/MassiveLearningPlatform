using Microsoft.AspNetCore.Mvc;

namespace be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController() { }

        [HttpGet]
        [Route("Profile")]
        public IActionResult GetProfile()
        {
            return Ok(new { Message = "User profile data" });
        }
    }
}
