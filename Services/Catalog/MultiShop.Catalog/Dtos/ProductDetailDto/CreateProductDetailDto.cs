namespace MultiShop.Catalog.Dtos.ProductDetailDto;

public sealed record CreateProductDetailDto
{
    public string ProductDescription { get; set; }
    public string ProductInfo { get; set; }
    public string ProductId { get; set; }
}