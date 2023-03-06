using crud_csharp.Database;
using crud_csharp.Models;
using crud_csharp.Models.DTOs;
using crud_csharp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            return await _context.Videos.Include(x => x.Category).ToListAsync();
        }

        public async Task<Video> FindById(string id)
        {
            return await _context.Videos.Include(x => x.Category).FirstAsync(x => x.Id == id);
        }

        public async Task<Video> Create(Video video)
        {
            Category category = await 
                _context.Categories.FirstAsync(x => x.Id == video.Category_id) ?? 
                throw new Exception("Category does not exist."); ;

            await _context.Videos.AddAsync(video);
            await _context.SaveChangesAsync();

            return video;
        }

        public async Task<Video> Update(VideoUpdateRequestDTO video, string id)
        {
            Video updatedVideo = await FindById(id) ?? throw new Exception("Video does not exist.");

            updatedVideo.Name = video.Name ?? updatedVideo.Name;
            updatedVideo.Description = video.Description ?? updatedVideo.Description;
            updatedVideo.Duration = video.Duration ?? updatedVideo.Duration;
            updatedVideo.Category_id = video.Category_id ?? updatedVideo.Category_id;

            _context.Videos.Update(updatedVideo);
            await _context.SaveChangesAsync();
            return updatedVideo;
        }

        public async Task<bool> Delete(string id)
        {
            Video video_aux = await FindById(id) ?? throw new Exception("Video does not exist.");

            _context.Videos.Remove(video_aux);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
