using crud_csharp.Models;
using crud_csharp.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace crud_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private readonly IUser _userRepository;

        public UserController(IUser userRepository)
        {
            _userRepository = userRepository;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            List<User> users = await _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<List<User>>> FindById([FromRoute] string id)
        {
            User user = await _userRepository.FindById(id);
            return Ok(user);
        }
    }
}