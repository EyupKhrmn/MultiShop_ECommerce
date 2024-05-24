using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services;

public interface IBasketService
{
    Task<BasketTotalDto> GetBasket(string userId);
    Task<bool> SaveBasket(BasketTotalDto basketTotalDto);
    Task<bool> DeleteBasket(string userId);
}