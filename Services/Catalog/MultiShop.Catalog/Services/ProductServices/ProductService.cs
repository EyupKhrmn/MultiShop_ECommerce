using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDto;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices;

public sealed class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<Product> _productCollection;

    public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        var values = await _productCollection.Find(_ => true).ToListAsync();
        return _mapper.Map<List<ResultProductDto>>(values);
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var values = _mapper.Map<Product>(updateProductDto);
        await _productCollection.FindOneAndReplaceAsync<Product>(_ => _.ProductId == updateProductDto.ProductId, values);
    }

    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        var values = _mapper.Map<Product>(createProductDto);
        await _productCollection.InsertOneAsync(values);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _productCollection.DeleteOneAsync(_=>_.ProductId == id);
    }

    public async Task<ResultProductDto> GetByIdProductAsync(string id)
    {
        var value = await _productCollection.Find<Product>(_ => _.ProductId == id).FirstOrDefaultAsync();
        return _mapper.Map<ResultProductDto>(value);
    }
}