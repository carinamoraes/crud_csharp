using crud_csharp.Models;

namespace crud_csharp.Repositories.Interfaces
{
    public interface IVideo
    {
        Task<List<Video>> GetAll();

        Task<Video> FindById(string id);

        Task<Video> Create(Video video);

        Task<Video> Update(Video video, string id);

        Task<Video> Delete(string id);
    }
}
