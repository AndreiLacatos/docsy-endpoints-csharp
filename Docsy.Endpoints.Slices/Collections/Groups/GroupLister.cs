using Docsy.Endpoints.Slices.Collections.Groups.Persistence.Entities;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Common.Persistence;

namespace Docsy.Endpoints.Slices.Collections.Groups;

internal sealed class GroupLister : IDataLister<GroupEntity, CollectionId>
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;

    public GroupLister(IMongoCollectionFactory mongoCollectionFactory)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
    }

    public Task<IEnumerable<GroupEntity>> ListEntities(CollectionId key)
    {
        throw new NotImplementedException();
    }
}
