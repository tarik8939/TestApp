using Microsoft.AspNetCore.Mvc;
using TestApp.Domain.Models;
using TestApp.Services.Services;

namespace TestApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getCategoriesTree")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesTree()
        {
            var categoriesTree = await _categoryService.GetTree();
            if (categoriesTree != null) return Ok(categoriesTree);

            return BadRequest(new { message = "Can't find category tree" });
        }
    }
}
