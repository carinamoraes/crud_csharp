using crud_csharp.Models;
using crud_csharp.Models.DTOs;

namespace crud_csharp.Repositories.Interfaces
{
    public interface ICategory
    {
        Task<List<Category>> GetAll();

        Task<Category> FindById(string id);

        Task<Category> Create(Category category);

        Task<Category> Update(CategoryUpdateRequestDTO category, string id);

        Task<bool> Delete(string id);
    }
}
