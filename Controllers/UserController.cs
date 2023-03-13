using crud_csharp.Models;
using crud_csharp.Models.DTOs;
using crud_csharp.Repositories;
using crud_csharp.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            List<User> users = await _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("findbyid/{id}")]
        [Authorize]
        public async Task<ActionResult<List<User>>> FindById([FromRoute] string id)
        {
            User user = await _userRepository.FindById(id);
            return Ok(user);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<User>> Create([FromBody] User user)
        {
            await _userRepository.Create(user);
            return Ok(user);
        }

        [HttpPut("update/{id}")]
        [Authorize]
        public async Task<ActionResult<User>> Update([FromBody] UserUpdateRequestDTO user, [FromRoute] string id)
        {
            User updatedUser = await _userRepository.Update(user, id);
            return Ok(updatedUser);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> Delete([FromRoute] string id)
        {
            bool deleted = await _userRepository.Delete(id);
            return Ok(deleted);
        }
    }
}