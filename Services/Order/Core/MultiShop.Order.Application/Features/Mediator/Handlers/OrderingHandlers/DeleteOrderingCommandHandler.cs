using System.Runtime.CompilerServices;
using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class DeleteOrderingCommandHandler(IGeneralRepository<Ordering> generalRepository)
    : IRequestHandler<DeleteOrderingRequest>
{
    private readonly IGeneralRepository<Ordering> _generalRepository = generalRepository;

    public async Task Handle(DeleteOrderingRequest request, CancellationToken cancellationToken)
    {
        var value = await _generalRepository.GetByIdAsync(request.Id);
        await _generalRepository.DeleteAsync(value);
    }
}