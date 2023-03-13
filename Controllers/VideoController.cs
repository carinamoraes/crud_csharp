using crud_csharp.Models;
using crud_csharp.Models.DTOs;
using crud_csharp.Repositories;
using crud_csharp.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult<List<Video>>> GetAll()
        {
            List<Video> videos = await _videoRepository.GetAll();
            return Ok(videos);
        }

        [HttpGet("findbyid/{id}")]
        [Authorize]
        public async Task<ActionResult<List<Video>>> FindById([FromRoute] string id)
        {
            Video video = await _videoRepository.FindById(id);
            return Ok(video);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Video>> Create([FromBody] Video video)
        {
            await _videoRepository.Create(video);
            return Ok(video);
        }

        [HttpPut("update/{id}")]
        [Authorize]
        public async Task<ActionResult<Video>> Update([FromBody] VideoUpdateRequestDTO video, [FromRoute] string id)
        {
            Video updatedVideo = await _videoRepository.Update(video, id);
            return Ok(updatedVideo);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        public async Task<ActionResult<bool>> Delete([FromRoute] string id)
        {
            bool deleted = await _videoRepository.Delete(id);
            return Ok(deleted);
        }
    }

}
