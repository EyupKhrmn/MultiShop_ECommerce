using MultiShop.Order.Application.Features.CQRS.Queries.OrderQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public sealed class GetOrderDetailByIdQueryHandler(IGeneralRepository<OrderDetail> generalRepository)
{
    private readonly IGeneralRepository<OrderDetail> _generalRepository = generalRepository;

    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
    {
        var value = await _generalRepository.GetByIdAsync(query.Id);
        return new GetOrderDetailByIdQueryResult
        {
            OrderDetailId = value.OrderDetailId,
            ProductId = value.ProductId,
            ProductName = value.ProductName,
            ProductPrice = value.ProductPrice,
            ProductAmount = value.ProductAmount,
            ProductTotalPrice = value.ProductTotalPrice,
            OrderingId = value.OrderingId,
            Ordering = value.Ordering
        };
    }
}