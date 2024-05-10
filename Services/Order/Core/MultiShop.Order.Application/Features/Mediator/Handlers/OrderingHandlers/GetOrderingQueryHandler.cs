using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingQueryHandler(IGeneralRepository<Ordering> generalRepository)
    : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
{
    private readonly IGeneralRepository<Ordering> _generalRepository = generalRepository;

    public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
    {
        var values = await _generalRepository.GetAllAsync();
        return values.Select(_ => new GetOrderingQueryResult
        {
            OrderingId = _.OrderingId,
            UserId = _.UserId,
            TotalPrice = _.TotalPrice,
            OrderDate = _.OrderDate
        }).ToList();
    }
}