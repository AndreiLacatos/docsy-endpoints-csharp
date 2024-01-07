using Docsy.Endpoints.Slices.Collections.Mapper;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Collections.Persistence.Entities;
using Docsy.Endpoints.Slices.Common.Persistence;

namespace Docsy.Endpoints.Slices.Collections;

public sealed class CollectionService : ICollectionService
{
    private readonly IDataReader<CollectionEntity, CollectionId> _collectionReader;
    private readonly IDataLister<CollectionEntity, ProjectId> _collectionLister;
    private readonly IDataWriter<CollectionEntity> _collectionWriter;

    public CollectionService(
        IDataReaderFactory dataReaderFactory,
        IDataListerFactory dataListerFactory,
        IDataWriterFactory dataWriterFactory)
    {
        _collectionReader = dataReaderFactory.GetReader<CollectionEntity, CollectionId>();
        _collectionLister = dataListerFactory.GetLister<CollectionEntity, ProjectId>();
        _collectionWriter = dataWriterFactory.GetWriter<CollectionEntity>();
    }

    public async Task<IEnumerable<Collection>> ListProjectCollections(
        ProjectId projectId)
    {
        var collections = await _collectionLister.ListEntities(projectId);
        return collections.Select(CollectionMapper.Map);
    }

    public async Task<Collection> GetCollection(CollectionId collectionId)
    {
        var collection = await _collectionReader.GetEntityOrDefault(collectionId);
        if (collection is null)
        {
            throw new CollectionNotFoundException(collectionId);
        }

        return CollectionMapper.Map(collection);
    }

    public async Task<Collection> CreateCollection(Collection collection)
    {
        var entity = CollectionMapper.Map(collection);
        var written = await _collectionWriter.WriteEntity(entity);
        return CollectionMapper.Map(written);
    }
}
