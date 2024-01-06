using Docsy.Endpoints.Slices.Collections.Groups.Persistence.Entities;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Collections.Persistence.Entities;
using Docsy.Endpoints.Slices.Common.Persistence;
using MongoDB.Driver;

namespace Docsy.Endpoints.Slices.Collections.Groups;

internal sealed class GroupLister : IDataLister<GroupEntity, CollectionId>
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;

    public GroupLister(IMongoCollectionFactory mongoCollectionFactory)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
    }

    public async Task<IEnumerable<GroupEntity>> ListEntities(CollectionId key)
    {
        var collections = _mongoCollectionFactory
            .GetCollection<CollectionEntity>();
        var filter = Builders<CollectionEntity>.Filter.Eq(
            collection => collection.CollectionId,
            key.GetName());
        var collection = await collections.Find(filter).FirstOrDefaultAsync();
        return collection?.Groups ?? Enumerable.Empty<GroupEntity>();
    }
}
