using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class UpdateOrderingCommandHandler(IGeneralRepository<Ordering> generalRepository)
    : IRequestHandler<UpdateOrderingRequest>
{
    private readonly IGeneralRepository<Ordering> _generalRepository = generalRepository;

    public async Task Handle(UpdateOrderingRequest request, CancellationToken cancellationToken)
    {
        var value = await _generalRepository.GetByIdAsync(request.OrderingId);
        value.OrderDate = request.OrderDate;
        value.TotalPrice = request.TotalPrice;
        value.UserId = request.UserId;
        
        await _generalRepository.UpdateAsync(value);
    }
}