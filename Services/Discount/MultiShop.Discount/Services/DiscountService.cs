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
        string query = "Select * from Coupons where CouponId = @couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId",id);
        using (var connection = _context.CreateConnection())
        {
            var value = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query,parameters);
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
        string query = "Insert Into Coupons (CouponId,Code,Rate,IsActive,ValidDate) Values (@couponId,@code,@rate,@isActive,@validDate)";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId",Guid.NewGuid());
        parameters.Add("@code",createCouponDto.Code);
        parameters.Add("@rate",createCouponDto.Rate);
        parameters.Add("@isActive",createCouponDto.IsActive);
        parameters.Add("@validDate",createCouponDto.ValidDate);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query,parameters);
        }
    }

    public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
    {
        string query =
            "Update Coupons set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@couponId",updateCouponDto.CouponId);
        parameters.Add("@code",updateCouponDto.Code);
        parameters.Add("@rate",updateCouponDto.Rate);
        parameters.Add("@isActive",updateCouponDto.IsActive);
        parameters.Add("@validDate",updateCouponDto.ValidDate);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query,parameters);
        }
    }
}