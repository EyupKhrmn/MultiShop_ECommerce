using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public sealed class UpdateOrderDetailCommandHandler(IGeneralRepository<OrderDetail> generalRepository)
{
    private readonly IGeneralRepository<OrderDetail> _generalRepository = generalRepository;

    public async Task Handle(UpdateOrderDetailCommand command)
    {
        var value = await _generalRepository.GetByIdAsync(command.OrderDetailId);
        value.ProductId = command.ProductId;
        value.ProductName = command.ProductName;
        value.ProductPrice = command.ProductPrice;
        value.ProductAmount = command.ProductAmount;
        value.ProductTotalPrice = command.ProductTotalPrice;
        value.OrderingId = command.OrderingId;
        value.Ordering = command.Ordering;
        
        await _generalRepository.UpdateAsync(value);
    }
}