using Hypesoft.Domain.Entities;
using Hypesoft.Domain.Repositories;
using MongoDB.Driver;

namespace Hypesoft.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IMongoCollection<Category> _collection;

    public CategoryRepository(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("hypesoft");
        _collection = database.GetCollection<Category>("categories");
    }

    public async Task<Category?> GetByIdAsync(Guid id)
        => await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<List<Category>> GetAllAsync()
        => await _collection.Find(_ => true).ToListAsync();

    public async Task AddAsync(Category category)
        => await _collection.InsertOneAsync(category);
}
