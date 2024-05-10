using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet("GetAllCoupons")]
        public async Task<IActionResult> GetAllCoupons()
        {
            var values = await _discountService.GetAllCouponAsync();
            return Ok(values);
        }

        [HttpGet("GetAllCouponsById")]
        public async Task<IActionResult> GetCouponsById(Guid id)
        {
            var value = await _discountService.GetCouponByIdAsync(id);
            return Ok(value);
        }

        [HttpPost("CreateCoupon")]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCoupon(createCouponDto);
            return Ok("Kupon Başarıyla Eklendi");
        }

        [HttpDelete("DeleteCoupon")]
        public async Task<IActionResult> DeleteCoupon(Guid id)
        {
            await _discountService.DeleteCouponAsync(id);
            return Ok("Kupon Başarıyla Silindi");
        }

        [HttpPut("UpdateCoupon")]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Kupon Başarıyla Güncellendi");
        }
    }
}
