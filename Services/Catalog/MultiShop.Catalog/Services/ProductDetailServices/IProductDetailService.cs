using MultiShop.Catalog.Dtos.ProductDetailDto;

namespace MultiShop.Catalog.Services.ProductDetailServices;

public interface IProductDetailService
{
    Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
    Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
    Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
    Task DeleteProductDetailAsync(string id);
    Task<ResultProductDetailDto> GetByIdProductDetailAsync(string id);
}