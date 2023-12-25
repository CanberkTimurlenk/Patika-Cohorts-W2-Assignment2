using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Models.Requests.Product;
using Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Services.Abstract;

namespace Patika_Akbank_Bootcamp_Cohorts_W2_HW1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllAsync(); 
            return Ok(categories); // return 200 + data
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
                return NotFound(); // return 404

            return Ok(category); // return 200 + data
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateRequest category)
        {
            await _categoryService.CreateCategoryAsync(category);
            return Created(); // return 201
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] CategoryUpdateRequest categoryToUpdate)
        {
            await _categoryService.UpdateCategoryAsync(id, categoryToUpdate);
            return NoContent(); // return 204
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent(); // return 204
        }
    }
}
