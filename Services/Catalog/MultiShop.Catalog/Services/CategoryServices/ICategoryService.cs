using MultiShop.Catalog.Dtos.CategoryDto;

namespace MultiShop.Catalog.Services.CategoryServices;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllCategoryAsync();
    Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task DeleteCategoryAsync(string id);
    Task<ResultCategoryDto> GetByIdCategoryAsync(string id);
}