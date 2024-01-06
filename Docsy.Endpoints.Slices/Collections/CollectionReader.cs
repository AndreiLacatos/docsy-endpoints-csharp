using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Collections.Persistence.Entities;
using Docsy.Endpoints.Slices.Common.Persistence;

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
        throw new NotImplementedException();
    }
}
