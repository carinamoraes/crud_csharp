using crud_csharp.Models;
using crud_csharp.Models.DTOs;
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
        public async Task<ActionResult<Category>> FindById([FromRoute] string id)
        {
            Category category = await _categoryRepository.FindById(id);
            return Ok(category);
        }

        [HttpPost]  
        public async Task<ActionResult<Category>> Create([FromBody] Category category)
        {
            await _categoryRepository.Create(category);
            return Ok(category);
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Category>> Update([FromBody] CategoryUpdateRequestDTO category, [FromRoute] string id)
        {   
            Category updatedCategory = await _categoryRepository.Update(category, id);
            return Ok(updatedCategory);    
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Delete([FromRoute] string id)
        {
            bool deleted = await _categoryRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
