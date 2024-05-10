using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public interface IDiscountService
{
    Task<List<ResultCouponDto>> GetAllCouponAsync();
    Task<ResultCouponDto> GetCouponByIdAsync(Guid id);
    Task DeleteCouponAsync(Guid id);
    Task CreateCoupon(CreateCouponDto createCouponDto);
    Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
}