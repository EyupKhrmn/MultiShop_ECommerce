using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public sealed class CreateAddressCommandHandler(IGeneralRepository<Address> generalRepository)
{
    private readonly IGeneralRepository<Address> _generalRepository = generalRepository;

    public async Task Handle(CreateAddressCommand createAddressCommand)
    {
        await _generalRepository.AddAsync(new Address
        {
            City = createAddressCommand.City,
            Detail = createAddressCommand.Detail,
            District = createAddressCommand.District,
            UserId = createAddressCommand.UserId
        });
    }
}