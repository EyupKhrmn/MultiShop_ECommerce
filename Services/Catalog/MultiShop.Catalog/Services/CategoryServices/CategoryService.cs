using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDto;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices;

public sealed class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
        var values = await _categoryCollection.Find(_ => true).ToListAsync();
        return _mapper.Map<List<ResultCategoryDto>>(values);
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        var value = _mapper.Map<Category>(updateCategoryDto);
        await _categoryCollection.FindOneAndReplaceAsync(_ => _.CategoryId == updateCategoryDto.CategoryId, value);
    }

    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        var value = _mapper.Map<Category>(createCategoryDto);
        await _categoryCollection.InsertOneAsync(value);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await _categoryCollection.DeleteOneAsync(id);
    }

    public async Task<ResultCategoryDto> GetByIdCategoryAsync(string id)
    {
        var value = await _categoryCollection.Find<Category>(_ => _.CategoryId == id).FirstOrDefaultAsync();
        return _mapper.Map<ResultCategoryDto>(value);
    }
}