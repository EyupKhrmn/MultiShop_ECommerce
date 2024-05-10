using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public sealed class UpdateAddressCommandHandler(IGeneralRepository<Address> generalRepository)
{
    private readonly IGeneralRepository<Address> _generalRepository = generalRepository;

    public async Task Handle(UpdateAddressCommand command)
    {
        var value = await _generalRepository.GetByIdAsync(command.AddressId);
        value.City = command.City;
        value.Detail = command.Detail;
        value.District = command.District;
        value.UserId = command.UserId;
        await _generalRepository.UpdateAsync(value);
    }
}