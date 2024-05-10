namespace MultiShop.Discount.Dtos;

public sealed record UpdateCouponDto
{
    public Guid CouponId { get; set; }
    public string Code { get; set; }
    public int Rate { get; set; }
    public bool IsActive { get; set; }
    public DateTime ValidDate { get; set; }
}