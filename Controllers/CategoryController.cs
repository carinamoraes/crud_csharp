using crud_csharp.Models;
using crud_csharp.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace crud_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : ControllerBase
    {

        private readonly ICategory _categoryRepository;

        public CategoryController(ICategory categoryRepository)
        {
            _categoryRepository = categoryRepository;

        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            List<Category> categories = await _categoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("findbyid/{id}")]
        public async Task<ActionResult<List<Category>>> FindById([FromRoute] string id)
        {
            Category category = await _categoryRepository.FindById(id);
            return Ok(category);
        }
    }
}
