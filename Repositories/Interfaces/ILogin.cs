using crud_csharp.Models;
using crud_csharp.Models.DTOs;

namespace crud_csharp.Repositories.Interfaces
{
    public interface ILogin
    {
        Task<dynamic> Login(LoginRequestDTO loginCredentials);
    }
}
