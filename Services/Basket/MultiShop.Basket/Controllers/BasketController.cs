using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController(IBasketService basketService, ILoginService loginService) : ControllerBase
    {
        private readonly IBasketService _basketService = basketService;
        private readonly ILoginService _loginService = loginService;

        [HttpGet("GetBasket")]
        public async Task<IActionResult> GetBasket(string userId)
        {
            var values = await _basketService.GetBasket(userId);
            
            if (values is null) return NotFound();
            
            return Ok(values);
        }

        [HttpPost("AddBasket")]
        public async Task<IActionResult> AddBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Sepetteki Değişiklikler Kaydedildi");
        }

        [HttpDelete("DeleteBasket")]
        public async Task<IActionResult> DeleteBasket(string userId)
        {
            await _basketService.DeleteBasket(userId);
            return Ok("Sepet Başarıyla Silindi");
        }
    }
}
