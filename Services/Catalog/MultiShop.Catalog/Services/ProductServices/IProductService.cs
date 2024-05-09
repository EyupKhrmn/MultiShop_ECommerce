using MultiShop.Catalog.Dtos.ProductDto;

namespace MultiShop.Catalog.Services.ProductServices;

public interface IProductService
{
    Task<List<ResultProductDto>> GetAllProductAsync();
    Task UpdateProductAsync(UpdateProductDto updateProductDto);
    Task CreateProductAsync(CreateProductDto createProductDto);
    Task DeleteProductAsync(string id);
    Task<ResultProductDto> GetByIdProductAsync(string id);
}