using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class CreateOrderingCommandHandler(IGeneralRepository<Ordering> generalRepository)
    : IRequestHandler<CreateOrderingCommand>
{
    private readonly IGeneralRepository<Ordering> _generalRepository = generalRepository;

    public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
        await _generalRepository.AddAsync(new Ordering
        {
            UserId = request.UserId,
            TotalPrice = request.TotalPrice,
            OrderDate = request.OrderDate
        });
    }
}