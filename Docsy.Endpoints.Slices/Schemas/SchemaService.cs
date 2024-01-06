using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Common.Persistence;
using Docsy.Endpoints.Slices.Schemas.Mapper;
using Docsy.Endpoints.Slices.Schemas.Models;
using Docsy.Endpoints.Slices.Schemas.Persistence.Entities;

namespace Docsy.Endpoints.Slices.Schemas;

public sealed class SchemaService : ISchemaService
{
    private readonly IDataLister<SchemaEntity, CollectionId> _collectionLister;

    public SchemaService(IDataListerFactory dataListerFactory)
    {
        _collectionLister = dataListerFactory.GetLister<SchemaEntity, CollectionId>();
    }

    public async Task<IEnumerable<Schema>> GetCollectionSchemas(CollectionId collectionId)
    {
        var schemas = await _collectionLister.ListEntities(collectionId);
        return schemas.Select(SchemaMapper.Map);
    }
}
