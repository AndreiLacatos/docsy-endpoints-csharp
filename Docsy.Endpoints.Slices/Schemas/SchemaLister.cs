using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Common.Persistence;
using Docsy.Endpoints.Slices.Schemas.Persistence.Entities;

namespace Docsy.Endpoints.Slices.Schemas;

internal sealed class SchemaLister : IDataLister<SchemaEntity, CollectionId>
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;

    public SchemaLister(IMongoCollectionFactory mongoCollectionFactory)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
    }

    public Task<IEnumerable<SchemaEntity>> ListEntities(CollectionId key)
    {
        throw new NotImplementedException();
    }
}
