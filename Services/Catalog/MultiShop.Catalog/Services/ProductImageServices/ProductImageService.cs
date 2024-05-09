using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDto;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices;

public class ProductImageService : IProductImageService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<ProductImage> _ProductImageCollection;

    public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _ProductImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImagesCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
    {
        var values = await _ProductImageCollection.Find(_ => true).ToListAsync();
        return _mapper.Map<List<ResultProductImageDto>>(values);
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
    {
        var values = _mapper.Map<ProductImage>(updateProductImageDto);
        await _ProductImageCollection.FindOneAndReplaceAsync<ProductImage>(_ => _.ProductImageId == updateProductImageDto.ProductImageId, values);
    }

    public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
    {
        var values = _mapper.Map<ProductImage>(createProductImageDto);
        await _ProductImageCollection.InsertOneAsync(values);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _ProductImageCollection.DeleteOneAsync(_=>_.ProductImageId == id);
    }

    public async Task<ResultProductImageDto> GetByIdProductImageAsync(string id)
    {
        var value = await _ProductImageCollection.Find<ProductImage>(_ => _.ProductImageId == id).FirstOrDefaultAsync();
        return _mapper.Map<ResultProductImageDto>(value);
    }
}