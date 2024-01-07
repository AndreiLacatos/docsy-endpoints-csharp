using Docsy.Endpoints.Slices.Collections.Persistence.Entities;
using Docsy.Endpoints.Slices.Common.Persistence;
using MongoDB.Driver;

namespace Docsy.Endpoints.Slices.Collections;

internal sealed class CollectionWriter : IDataWriter<CollectionEntity>
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;

    public CollectionWriter(IMongoCollectionFactory mongoCollectionFactory)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
    }

    public async Task<CollectionEntity> WriteEntity(CollectionEntity entity)
    {
        var collections = _mongoCollectionFactory.GetCollection<CollectionEntity>();
        var filter = Builders<CollectionEntity>.Filter.Eq(
            collection => collection.CollectionId,
            entity.CollectionId);
        var update = Builders<CollectionEntity>.Update
            .Set(collection => collection.ProjectId, entity.ProjectId)
            .Set(collection => collection.CollectionId, entity.CollectionId)
            .Set(collection => collection.CollectionName, entity.CollectionName)
            .Set(collection => collection.Description, entity.Description)
            .Set(collection => collection.Groups, entity.Groups);
        var options = new UpdateOptions
        {
            IsUpsert = true,
        };
        await collections.UpdateOneAsync(filter, update, options);
        return entity;
    }
}
