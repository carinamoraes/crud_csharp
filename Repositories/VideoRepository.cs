using crud_csharp.Database;
using crud_csharp.Models;
using crud_csharp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace crud_csharp.Repositories
{
    public class VideoRepository : IVideo
    {
        private readonly DB_Context _context;

        public VideoRepository(DB_Context context)
        {
            _context = context;
        }

        public async Task<List<Video>> GetAll()
        {
            return await _context.Videos.ToListAsync();
        }

        public async Task<Video> FindById(string id)
        {
            return await _context.Videos.FirstAsync(x => x.Id == id);
        }

        public Task<Video> Create(Video video)
        {
            throw new NotImplementedException();
        }

        public async Task<Video> Update(Video video, string id)
        {
            throw new NotImplementedException();
        }

        public Task<Video> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
