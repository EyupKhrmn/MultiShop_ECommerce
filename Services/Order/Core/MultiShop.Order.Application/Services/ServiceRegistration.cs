using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

namespace MultiShop.Order.Application.Services;

public static class ServiceRegistration
{
    public static void AddApplicationService(this IServiceCollection service,IConfiguration configuration)
    {
        service.AddScoped<GetAddressQueryHandler>();
        service.AddScoped<GetAddressByIdQueryHandler>();
        service.AddScoped<CreateAddressCommandHandler>();
        service.AddScoped<UpdateAddressCommandHandler>();
        service.AddScoped<DeleteAddressCommandHandler>();

        service.AddScoped<GetOrderDetailQueryHandler>();
        service.AddScoped<GetOrderDetailByIdQueryHandler>();
        service.AddScoped<UpdateOrderDetailCommandHandler>();
        service.AddScoped<RemoveOrderDetailCommandHandler>();
        service.AddScoped<CreateOrderDetailCommandHandler>();
        
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
    }
}