using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Persistence.Entities;
using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Docsy.Endpoints.Slices.Common.Persistence;

namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints;

internal sealed class EndpointLister : IDataLister<EndpointEntity, GroupId>
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;

    public EndpointLister(IMongoCollectionFactory mongoCollectionFactory)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
    }

    public Task<IEnumerable<EndpointEntity>> ListEntities(GroupId key)
    {
        throw new NotImplementedException();
    }
}
