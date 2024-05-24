using System.Text.Json;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;

namespace MultiShop.Basket.Services;

public sealed class BasketService(RedisService redisService) : IBasketService
{
    private readonly RedisService _redisService = redisService;

    public async Task<BasketTotalDto> GetBasket(string userId)
    {
        var basket = await _redisService.GetDb().StringGetAsync(userId);
        return JsonSerializer.Deserialize<BasketTotalDto>(basket);

    }

    public async Task<bool> SaveBasket(BasketTotalDto basketTotalDto)
    {
        return await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId,JsonSerializer.Serialize((basketTotalDto)));
    }

    public async Task<bool> DeleteBasket(string userId)
    {
        return await _redisService.GetDb().KeyDeleteAsync(userId);
    }
}