using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Common.Persistence;
using Docsy.Endpoints.Slices.Schemas.Persistence.Entities;
using MongoDB.Driver;

namespace Docsy.Endpoints.Slices.Schemas;

internal sealed class SchemaLister : IDataLister<SchemaEntity, CollectionId>
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;

    public SchemaLister(IMongoCollectionFactory mongoCollectionFactory)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
    }

    public async Task<IEnumerable<SchemaEntity>> ListEntities(CollectionId key)
    {
        var schemas = _mongoCollectionFactory
            .GetCollection<SchemaEntity>();
        var filter = Builders<SchemaEntity>.Filter.Eq(
            schema => schema.CollectionId,
            key.GetName());
        return await schemas.Find(filter).ToListAsync();
    }
}
