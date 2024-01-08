using Docsy.Endpoints.Slices.Collections.Groups.Mapper;
using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Docsy.Endpoints.Slices.Collections.Persistence.Entities;
using Docsy.Endpoints.Slices.Common.Persistence;
using MongoDB.Driver;

namespace Docsy.Endpoints.Slices.Collections.Groups;

internal sealed class GroupWriter : IDataWriter<Group>
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;

    public GroupWriter(IMongoCollectionFactory mongoCollectionFactory)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
    }

    public async Task<Group> WriteEntity(Group obj)
    {
        var collections = _mongoCollectionFactory.GetCollection<CollectionEntity>();
        var filters = Builders<CollectionEntity>.Filter.Eq(
            collection => collection.CollectionId,
            obj.GroupId.CollectionId.GetName());
        var entity = GroupMapper.Map(obj);
        var updates = Builders<CollectionEntity>.Update
            .Push(collection => collection.Groups, entity);
        await collections.UpdateOneAsync(filters, updates);
        return GroupMapper.Map(entity);
    }
}
