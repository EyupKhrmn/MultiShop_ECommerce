namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderQueries;

public sealed class GetOrderDetailQuery(int id)
{
    public int Id { get; set; } = id;
}