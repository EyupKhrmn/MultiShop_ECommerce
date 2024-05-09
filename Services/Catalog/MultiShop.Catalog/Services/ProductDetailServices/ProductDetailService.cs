using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDto;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<ProductDetail> _ProductDetailCollection;

    public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _ProductDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailsCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
    {
        var values = await _ProductDetailCollection.Find(_ => true).ToListAsync();
        return _mapper.Map<List<ResultProductDetailDto>>(values);
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
        await _ProductDetailCollection.FindOneAndReplaceAsync<ProductDetail>(_ => _.ProductDetailId == updateProductDetailDto.ProductDetailId, values);
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
    {
        var values = _mapper.Map<ProductDetail>(createProductDetailDto);
        await _ProductDetailCollection.InsertOneAsync(values);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _ProductDetailCollection.DeleteOneAsync(_=>_.ProductDetailId == id);
    }

    public async Task<ResultProductDetailDto> GetByIdProductDetailAsync(string id)
    {
        var value = await _ProductDetailCollection.Find<ProductDetail>(_ => _.ProductDetailId == id).FirstOrDefaultAsync();
        return _mapper.Map<ResultProductDetailDto>(value);
    }
}