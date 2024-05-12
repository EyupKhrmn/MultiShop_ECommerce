using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public sealed class CreateOrderDetailCommandHandler(IGeneralRepository<OrderDetail> generalRepository)
{
    private readonly IGeneralRepository<OrderDetail> _generalRepository = generalRepository;

    public async Task Handle(CreateOrderDetailCommand command)
    {
        var value = new OrderDetail
        {
            ProductId = command.ProductId,
            ProductName = command.ProductName,
            ProductPrice = command.ProductPrice,
            ProductAmount = command.ProductAmount,
            ProductTotalPrice = command.ProductTotalPrice,
            OrderingId = command.OrderingId,
        };

        await _generalRepository.AddAsync(value);
    }
}