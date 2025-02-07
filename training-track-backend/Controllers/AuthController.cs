using Microsoft.AspNetCore.Mvc;
using training_track_backend.DTOs;
using training_track_backend.Services;

namespace training_track_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<JwtDTO?>> Login(LoginDTO loginDTO)
        {
            JwtDTO? jwt = await _authService.Login(loginDTO);
            
            if (jwt == null)
            {
                return NotFound(null);
            }

            return Ok(jwt);
        }

        [HttpPost("register")]
        public async Task<ActionResult<JwtDTO?>> Register(RegisterDTO registerDTO)
        {
            JwtDTO? jwt = await _authService.Register(registerDTO);

            if (jwt == null)
            {
                return Conflict("");
            }

            return Ok(jwt);
        }
    }
}
