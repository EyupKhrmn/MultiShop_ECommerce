using Microsoft.Extensions.Options;
using MultiShop.Catalog.Mapping;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ExtensionsServices;

public static class ServiceRegistration
{
    public static void AddCatalogServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductDetailService, ProductDetailService>();
        services.AddScoped<IProductImageService, ProductImageService>();

        services.AddAutoMapper(typeof(GeneralMapping));

        services.AddScoped<IDatabaseSettings>(st => st.GetRequiredService<IOptions<DatabaseSettings>>().Value);
    }
}