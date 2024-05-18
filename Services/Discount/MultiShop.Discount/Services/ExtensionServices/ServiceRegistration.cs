using MultiShop.Discount.Context;

namespace MultiShop.Discount.Services.ExtensionServices;

public static class ServiceRegistration
{
    public static void AddDiscountServices(this IServiceCollection services)
    {
        services.AddTransient<DiscountContext>();
        services.AddTransient<IDiscountService,DiscountService>();
    }
}