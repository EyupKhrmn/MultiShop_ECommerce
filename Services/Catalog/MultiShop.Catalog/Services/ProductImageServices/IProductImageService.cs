using MultiShop.Catalog.Dtos.ProductImageDto;

namespace MultiShop.Catalog.Services.ProductImageServices;

public interface IProductImageService
{
    Task<List<ResultProductImageDto>> GetAllProductImageAsync();
    Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
    Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
    Task DeleteProductImageAsync(string id);
    Task<ResultProductImageDto> GetByIdProductImageAsync(string id);
}