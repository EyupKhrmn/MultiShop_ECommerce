using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public sealed class RemoveOrderDetailCommandHandler(IGeneralRepository<OrderDetail> generalRepository)
{
    private readonly IGeneralRepository<OrderDetail> _generalRepository = generalRepository;

    public async Task Handle(RemoveOrderDetailCommand command)
    {
        var value = await _generalRepository.GetByIdAsync(command.Id);
        await _generalRepository.DeleteAsync(value);
    }
}