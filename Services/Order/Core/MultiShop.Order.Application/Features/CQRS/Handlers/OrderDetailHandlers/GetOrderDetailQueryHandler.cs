using System.Runtime.CompilerServices;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public sealed class GetOrderDetailQueryHandler(IGeneralRepository<OrderDetail> generalRepository)
{
    private readonly IGeneralRepository<OrderDetail> _generalRepository = generalRepository;

    public async Task<List<GetOrderDetailQueryResult>> Handle(GetOrderDetailQuery query)
    {
        var value = await _generalRepository.GetAllAsync();
        return value.Select(_ => new GetOrderDetailQueryResult
        {
            OrderDetailId = _.OrderDetailId,
            ProductId = _.ProductId,
            ProductName = _.ProductName,
            ProductPrice = _.ProductPrice,
            ProductAmount = _.ProductAmount,
            ProductTotalPrice = _.ProductTotalPrice,
            OrderingId = _.OrderingId,
            Ordering = _.Ordering
        }).ToList();
    }
}