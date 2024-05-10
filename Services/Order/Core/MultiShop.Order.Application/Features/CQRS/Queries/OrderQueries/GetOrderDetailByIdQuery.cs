namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderQueries;

public sealed class GetOrderDetailByIdQuery(int id)
{
    public int Id { get; set; } = id;
}