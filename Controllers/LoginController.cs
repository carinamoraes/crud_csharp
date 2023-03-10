using crud_csharp.Models;
using crud_csharp.Repositories.Interfaces;
using crud_csharp.Repositories;
using Microsoft.AspNetCore.Mvc;
using crud_csharp.Models.DTOs;

namespace crud_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _loginRepository;

        public LoginController(ILogin loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> Login([FromBody] LoginRequestDTO loginCredentials)
        {
            var loggedUser = await _loginRepository.Login(loginCredentials);
            return Ok(loggedUser);
        }

    }
}
