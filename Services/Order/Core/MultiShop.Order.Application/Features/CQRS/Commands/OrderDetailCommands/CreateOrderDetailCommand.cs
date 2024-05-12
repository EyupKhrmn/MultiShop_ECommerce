using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;

public sealed record CreateOrderDetailCommand
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductAmount { get; set; }
    public decimal ProductTotalPrice { get; set; }
    public int OrderingId { get; set; }
}