using Docsy.Endpoints.Slices.Collections.Mapper;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Collections.Persistence.Entities;
using Docsy.Endpoints.Slices.Common.Persistence;
using MongoDB.Driver;

namespace Docsy.Endpoints.Slices.Collections;

internal sealed class CollectionWriter : IDataWriter<Collection>
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;

    public CollectionWriter(IMongoCollectionFactory mongoCollectionFactory)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
    }

    public async Task<Collection> WriteEntity(Collection obj)
    {
        var collections = _mongoCollectionFactory.GetCollection<CollectionEntity>();
        var filter = Builders<CollectionEntity>.Filter.Eq(
            collection => collection.CollectionId,
            obj.CollectionId.GetName());
        var entity = CollectionMapper.Map(obj);
        var update = Builders<CollectionEntity>.Update
            .Set(collection => collection.ProjectId, entity.ProjectId)
            .Set(collection => collection.CollectionId, entity.CollectionId)
            .Set(collection => collection.CollectionName, entity.CollectionName)
            .Set(collection => collection.Description, entity.Description)
            .Set(collection => collection.Version, entity.Version)
            .Set(collection => collection.Groups, entity.Groups);
        var options = new UpdateOptions
        {
            IsUpsert = true,
        };
        await collections.UpdateOneAsync(filter, update, options);
        return CollectionMapper.Map(entity);
    }
}
