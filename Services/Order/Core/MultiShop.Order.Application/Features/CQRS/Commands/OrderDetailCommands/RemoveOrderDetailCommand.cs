namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;

public sealed class RemoveOrderDetailCommand(int id)
{
    public int Id { get; set; } = id;
}