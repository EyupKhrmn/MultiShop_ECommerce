namespace MultiShop.Basket.Dtos;

public sealed class BasketTotalDto
{
    public string UserId { get; set; }
    public string DiscountCode { get; set; }
    public int? DiscountRate { get; set; } = 0;
    public List<BasketItemDto> BasketItems { get; set; }
    public decimal TotalPrice { get => BasketItems.Sum(_ => _.Price * _.Quantity); }
}