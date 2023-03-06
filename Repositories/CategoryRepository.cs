using crud_csharp.Database;
using crud_csharp.Models;
using crud_csharp.Models.DTOs;
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

        public async Task<Category> Create(Category category)
        {
           await _context.Categories.AddAsync(category);
           await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> Update(CategoryUpdateRequestDTO category, string id)
        {
            Category updatedCategory = await FindById(id) ?? throw new Exception("Category does not exist.");

            updatedCategory.Name = category.Name ?? updatedCategory.Name;
            updatedCategory.Description = category.Description ?? updatedCategory.Description;

            _context.Categories.Update(updatedCategory);
            await _context.SaveChangesAsync();
            return updatedCategory;
        }

        public async Task<bool> Delete(string id)
        {
            Category category_aux = await FindById(id) ?? throw new Exception("Category does not exist.");

            _context.Categories.Remove(category_aux);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
