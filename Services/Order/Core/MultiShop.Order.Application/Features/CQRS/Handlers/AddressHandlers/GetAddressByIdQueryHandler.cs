using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public sealed class GetAddressByIdQueryHandler(IGeneralRepository<Address> generalRepository)
{
    private readonly IGeneralRepository<Address> _generalRepository = generalRepository;

    public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
    {
        var values = await _generalRepository.GetByIdAsync(getAddressByIdQuery.Id);
        return new GetAddressByIdQueryResult
        {
            AddressId = values.AddressId,
            City = values.City,
            Detail = values.Detail,
            District = values.District,
            UserId = values.UserId
        };
    }
}