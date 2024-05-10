namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;

public sealed class DeleteAddressCommand(int id)
{
    public int Id { get; set; } = id;
}