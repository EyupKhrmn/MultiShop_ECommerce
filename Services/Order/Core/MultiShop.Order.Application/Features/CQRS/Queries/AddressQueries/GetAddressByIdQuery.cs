namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

public sealed class GetAddressByIdQuery(int id)
{
    public int Id { get; set; } = id;
}