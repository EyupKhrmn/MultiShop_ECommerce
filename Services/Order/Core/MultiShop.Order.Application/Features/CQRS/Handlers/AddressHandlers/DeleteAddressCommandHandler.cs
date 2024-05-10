using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public sealed class DeleteAddressCommandHandler(IGeneralRepository<Address> generalRepository)
{
    private readonly IGeneralRepository<Address> _generalRepository = generalRepository;

    public async Task Handle(DeleteAddressCommand deleteAddressCommand)
    {
        var value = await _generalRepository.GetByIdAsync(deleteAddressCommand.Id);
        await _generalRepository.DeleteAsync(value);
    }
}