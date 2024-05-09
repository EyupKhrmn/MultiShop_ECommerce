using AutoMapper;
using MultiShop.Catalog.Dtos.CategoryDto;
using MultiShop.Catalog.Dtos.ProductDetailDto;
using MultiShop.Catalog.Dtos.ProductDto;
using MultiShop.Catalog.Dtos.ProductImageDto;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();

        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();

        CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
        CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();

        CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
        CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
        CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
    }
}