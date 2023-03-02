using crud_csharp.Models;

namespace crud_csharp.Repositories.Interfaces
{
    public interface ICategory
    {
        Task<List<Category>> GetAll();

        Task<Category> FindById(string id);

        Task<Category> Create(Category category);

        Task<Category> Update(Category category, string id);

        Task<Category> Delete(string id);
    }
}
