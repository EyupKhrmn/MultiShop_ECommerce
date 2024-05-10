using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public sealed class GetAddressQueryHandler(IGeneralRepository<Address> generalRepository)
{
    private readonly IGeneralRepository<Address> _generalRepository = generalRepository;
    
    public async Task<List<GetAddressQueryResult>> Handle()
    {
        var values = await _generalRepository.GetAllAsync();
        
        return values.Select(_=> new GetAddressQueryResult
        {
            AddressId = _.AddressId,
            City = _.City,
            Detail = _.Detail,
            District = _.District,
            UserId = _.UserId
        }).ToList();
    }
}