using Application.Catalog;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ViewModel.Catalog;
using ViewModel.Common;

namespace BackendApi.Controllers
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

        [HttpGet("GetCategoryPaging")]
        public async Task<IActionResult> GetCategoryPaging([FromQuery] GetCategoryPagingRequest request)
        {
            var categories = await _categoryService.GetCategoryPaging(request);
            return Ok(categories);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int categoryId)
        {
            if (categoryId <= 0)
                return BadRequest("Category Id not must be less than 0");
            var category = await _categoryService.GetById(categoryId);
            return Ok(category);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var category = await _categoryService.CreateCategory(request);
            return Ok(category);
        }

        [HttpPut("UpdateCategory")]
        public async Task<ApiResult<bool>> UpdateCategory(CategoryViewModel request)
        {

            return await _categoryService.UpdateCategory(request);
        }

        //[HttpDelete("DeleteCategory")]
        //public async Task<IActionResult> DeleteCategory(int id)
        //{

        //    var category = await _categoryService.DeleteCategory(id);
        //    return Ok(category);
        //}
    }
}
