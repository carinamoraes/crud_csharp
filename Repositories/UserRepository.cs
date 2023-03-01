using crud_csharp.Database;
using crud_csharp.Models;
using crud_csharp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace crud_csharp.Repositories
{
    public class UserRepository : IUser
    {
        private readonly DB_Context _context;

        public UserRepository(DB_Context context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> FindById(string id)
        {
            return await _context.Users.FirstAsync(x => x.Id == id);
        }

        public Task<User> Create(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Update(User user, string id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
