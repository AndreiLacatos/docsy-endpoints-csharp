using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Collections.Persistence.Entities;
using Docsy.Endpoints.Slices.Common.Persistence;
using MongoDB.Driver;

namespace Docsy.Endpoints.Slices.Collections;

internal sealed class CollectionReader : IDataReader<CollectionEntity, CollectionId>
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;

    public CollectionReader(IMongoCollectionFactory mongoCollectionFactory)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
    }

    public Task<CollectionEntity?> GetEntityOrDefault(CollectionId key)
    {
        var collections = _mongoCollectionFactory.GetCollection<CollectionEntity>();
        var filters = Builders<CollectionEntity>.Filter.Eq(
            collection => collection.CollectionId,
            key.GetName());
        return collections.Find(filters).FirstOrDefaultAsync()!;
    }
}
