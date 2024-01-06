using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Collections.Persistence.Entities;
using Docsy.Endpoints.Slices.Common.Persistence;
using MongoDB.Driver;

namespace Docsy.Endpoints.Slices.Collections;

internal sealed class CollectionLister : IDataLister<CollectionEntity, ProjectId>
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;

    public CollectionLister(IMongoCollectionFactory mongoCollectionFactory)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
    }

    public async Task<IEnumerable<CollectionEntity>> ListEntities(ProjectId key)
    {
        var collections = _mongoCollectionFactory
            .GetCollection<CollectionEntity>();
        var filter = Builders<CollectionEntity>.Filter.Eq(
            collection => collection.ProjectId,
            key.GetName());
        return await collections.Find(filter).ToListAsync();
    }
}
