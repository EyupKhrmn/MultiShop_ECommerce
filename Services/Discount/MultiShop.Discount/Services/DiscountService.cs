using System.Runtime.CompilerServices;
using Dapper;
using Microsoft.AspNetCore.Identity;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public class DiscountService : IDiscountService
{
    private readonly DiscountContext _context;

    public DiscountService(DiscountContext context)
    {
        _context = context;
    }

    public async Task<List<ResultCouponDto>> GetAllCouponAsync()
    {
        string query = "Select * From Coupons";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultCouponDto>(query);
            return values.ToList();
        }
    }

    public async Task<ResultCouponDto> GetCouponByIdAsync(Guid id)
    {
        string query = "Select * from Coupons where CouponIs = @couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId",id);
        using (var connection = _context.CreateConnection())
        {
            var value = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query);
            return value;
        }
    }

    public async Task DeleteCouponAsync(Guid id)
    {
        string query = "Delete From Coupons where CouponId = @couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId",id);
        using (var connections = _context.CreateConnection())
        {
            await connections.ExecuteAsync(query,parameters);
        }
    }

    public async Task CreateCoupon(CreateCouponDto createCouponDto)
    {
        string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
        var paramaters = new DynamicParameters();
        paramaters.Add("@code",createCouponDto.Code);
        paramaters.Add("@rate",createCouponDto.Rate);
        paramaters.Add("@isActive",createCouponDto.IsActive);
        paramaters.Add("@validDate",createCouponDto.ValidDate);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query);
        }
    }

    public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
    {
        string query =
            "Update Coupons set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
        var paramaters = new DynamicParameters();
        paramaters.Add("@couponId",updateCouponDto.CouponId);
        paramaters.Add("@code",updateCouponDto.Code);
        paramaters.Add("@rate",updateCouponDto.Rate);
        paramaters.Add("@isActive",updateCouponDto.IsActive);
        paramaters.Add("@validDate",updateCouponDto.ValidDate);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query);
        }
    }
}