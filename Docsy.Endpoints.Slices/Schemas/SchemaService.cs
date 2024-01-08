using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Common.Persistence;
using Docsy.Endpoints.Slices.Schemas.Mapper;
using Docsy.Endpoints.Slices.Schemas.Models;
using Docsy.Endpoints.Slices.Schemas.Persistence.Entities;

namespace Docsy.Endpoints.Slices.Schemas;

public sealed class SchemaService : ISchemaService
{
    private readonly IDataLister<SchemaEntity, CollectionId> _collectionLister;
    private readonly IDataLister<Schema, CollectionId> _collectionStageLister;
    private readonly IDataWriter<Schema> _collectionStageWriter;

    public SchemaService(
        IDataListerFactory dataListerFactory,
        IDataWriterFactory dataWriterFactory)
    {
        _collectionLister = dataListerFactory.GetLister<SchemaEntity, CollectionId>();
        _collectionStageLister = dataListerFactory.GetStageLister<Schema, CollectionId>();
        _collectionStageWriter = dataWriterFactory.GetStageWriter<Schema>();
    }

    public async Task<IEnumerable<Schema>> GetCollectionSchemas(
        CollectionId collectionId)
    {
        var schemas = await _collectionLister
            .ListEntities(collectionId);
        return schemas.Select(SchemaMapper.Map);
    }

    public async Task<IEnumerable<Schema>> GetStagedCollectionSchemas(
        CollectionId collectionId)
    {
        var schemas = await _collectionStageLister
            .ListEntities(collectionId);
        schemas = schemas.ToArray();
        if (!schemas.Any())
        {
            schemas = await GetCollectionSchemas(collectionId);
            schemas = schemas.ToArray();
            foreach (var item in schemas)
            {
                await _collectionStageWriter.WriteEntity(item);
            }
        }

        return schemas;
    }
}
