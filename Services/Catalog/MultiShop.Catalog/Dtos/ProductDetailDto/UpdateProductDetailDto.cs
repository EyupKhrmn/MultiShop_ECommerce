namespace MultiShop.Catalog.Dtos.ProductDetailDto;

public sealed record UpdateProductDetailDto
{
    public string ProductDetailId { get; set; }
    public string ProductDescription { get; set; }
    public string ProductInfo { get; set; }
    public string ProductId { get; set; }
}