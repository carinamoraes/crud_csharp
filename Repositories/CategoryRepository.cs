using crud_csharp.Database;
using crud_csharp.Models;
using crud_csharp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace crud_csharp.Repositories
{
    public class CategoryRepository : ICategory
    {
        private readonly DB_Context _context;

        public CategoryRepository(DB_Context context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> FindById(string id)
        {
            return await _context.Categories.FirstAsync(x => x.Id == id);
        }

        public Task<Category> Create(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Update(Category category, string id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
