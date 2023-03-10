using crud_csharp.Database;
using crud_csharp.Models;
using crud_csharp.Models.DTOs;
using crud_csharp.Repositories.Interfaces;
using crud_csharp.Middleware;
using Microsoft.EntityFrameworkCore;

namespace crud_csharp.Repositories
{
    public class LoginRepository : ILogin
    {
        private readonly DB_Context _context;

        public LoginRepository(DB_Context context)
        {
            _context = context;
        }

        public async Task<dynamic> Login(LoginRequestDTO loginCredentials) {
            string hashPassword = loginCredentials.Password.GenerateHashPassword();

            User user = await 
                _context.Users.FirstOrDefaultAsync(x => x.Email == loginCredentials.Email && x.Password == hashPassword) ?? 
                throw new Exception("Invalid email or password.");

            user.Password = "";

            var token = TokenService.GenerateToken(user);

          return new { user, token };
        }

    }
}
