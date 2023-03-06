using crud_csharp.Models;
using crud_csharp.Models.DTOs;

namespace crud_csharp.Repositories.Interfaces
{
    public interface IVideo
    {
        Task<List<Video>> GetAll();

        Task<Video> FindById(string id);

        Task<Video> Create(Video video);

        Task<Video> Update(VideoUpdateRequestDTO video, string id);

        Task<bool> Delete(string id);
    }
}
