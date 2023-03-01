using crud_csharp.Models;

namespace crud_csharp.Repositories.Interfaces
{
    public interface IUser
    {
        Task<List<User>> GetAll();

        Task<User> FindById(string id);

        Task<User> Create(User user);

        Task<User> Update(User user, string id);

        Task<User> Delete(string id);
    }
}
