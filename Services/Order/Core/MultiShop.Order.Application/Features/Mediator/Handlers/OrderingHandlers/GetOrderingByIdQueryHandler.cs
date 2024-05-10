using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public sealed class GetOrderingByIdQueryHandler(IGeneralRepository<Ordering> generalRepository) : IRequestHandler<GetOrderingByIdQuery,GetOrderingByIdQueryResult>
{
    private readonly IGeneralRepository<Ordering> _generalRepository = generalRepository;
    
    public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _generalRepository.GetByIdAsync(request.Id);
        return new GetOrderingByIdQueryResult
        {
            OrderDate = value.OrderDate,
            OrderingId = value.OrderingId,
            TotalPrice = value.TotalPrice,
            UserId = value.UserId
        };
    }
}