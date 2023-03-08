using crud_csharp.Database;
using crud_csharp.Models;
using crud_csharp.Models.DTOs;
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

        public async Task<User> Create(User user)
        {
            user.HashPassword();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> Update(UserUpdateRequestDTO user, string id)
        {
            User updatedUser = await FindById(id) ?? throw new Exception("User does not exist.");

            updatedUser.Name = user.Name ?? updatedUser.Name;
            updatedUser.Email = user.Email ?? updatedUser.Email;

            _context.Users.Update(updatedUser);
            await _context.SaveChangesAsync();
            return updatedUser;
        }

        public async Task<bool> Delete(string id)
        {
            User user_aux = await FindById(id) ?? throw new Exception("User does not exist.");

            _context.Users.Remove(user_aux);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
