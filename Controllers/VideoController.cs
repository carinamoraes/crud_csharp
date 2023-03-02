using crud_csharp.Models;
using crud_csharp.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace crud_csharp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class VideoController : ControllerBase
    {


        private readonly IVideo _videoRepository;

        public VideoController(IVideo videoRepository)
        {
            _videoRepository = videoRepository;

        }

        [HttpGet]
        public async Task<ActionResult<List<Video>>> GetAll()
        {
            List<Video> videos = await _videoRepository.GetAll();
            return Ok(videos);
        }

        [HttpGet("findbyid/{id}")]
        public async Task<ActionResult<List<Video>>> FindById([FromRoute] string id)
        {
            Video video = await _videoRepository.FindById(id);
            return Ok(video);
        }
    }

}
