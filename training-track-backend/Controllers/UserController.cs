using Microsoft.AspNetCore.Mvc;
using training_track_backend.Models;
using training_track_backend.Services;

namespace training_track_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User?>> CreateUser([FromBody] User user)
        {
            return Ok(await _userService.CreateUser(user));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User?>> GetUserById([FromRoute] int id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>?>> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }
    }
}
