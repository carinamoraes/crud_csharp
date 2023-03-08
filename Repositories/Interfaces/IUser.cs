using crud_csharp.Models;
using crud_csharp.Models.DTOs;

namespace crud_csharp.Repositories.Interfaces
{
    public interface IUser
    {
        Task<List<User>> GetAll();

        Task<User> FindById(string id);

        Task<User> Create(User user);

        Task<User> Update(UserUpdateRequestDTO user, string id);

        Task<bool> Delete(string id);
    }
}
