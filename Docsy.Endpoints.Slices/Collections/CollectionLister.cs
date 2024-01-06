using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Collections.Persistence.Entities;
using Docsy.Endpoints.Slices.Common.Persistence;

namespace Docsy.Endpoints.Slices.Collections;

internal sealed class CollectionLister : IDataLister<CollectionEntity, ProjectId>
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;

    public CollectionLister(IMongoCollectionFactory mongoCollectionFactory)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
    }

    public Task<IEnumerable<CollectionEntity>> ListEntities(ProjectId key)
    {
        throw new NotImplementedException();
    }
}
