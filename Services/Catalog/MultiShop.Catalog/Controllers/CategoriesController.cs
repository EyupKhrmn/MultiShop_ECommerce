using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDto;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return Ok(values);
        }
        
        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var values = await _categoryService.GetByIdCategoryAsync(id);
            return Ok(values);
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori Başarıyla Eklendi");
        }

        [HttpDelete("CategoryDelete")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori Başarıyla Silindi");
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori Başarıyla Güncellendi");
        }
    }
}
