using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Persistence.Entities;
using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Docsy.Endpoints.Slices.Common.Persistence;
using MongoDB.Driver;

namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints;

internal sealed class EndpointLister : IDataLister<EndpointEntity, GroupId>
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;

    public EndpointLister(IMongoCollectionFactory mongoCollectionFactory)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
    }

    public async Task<IEnumerable<EndpointEntity>> ListEntities(GroupId key)
    {
        var endpoints = _mongoCollectionFactory
            .GetCollection<EndpointEntity>();
        var filter = Builders<EndpointEntity>.Filter.Eq(
            endpoint => endpoint.GroupId,
            key.GetName());
        return await endpoints.Find(filter).ToListAsync();
    }
}
