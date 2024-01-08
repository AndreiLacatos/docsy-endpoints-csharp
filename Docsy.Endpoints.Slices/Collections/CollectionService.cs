using Docsy.Endpoints.Slices.Collections.Mapper;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Collections.Persistence.Entities;
using Docsy.Endpoints.Slices.Common.Persistence;

namespace Docsy.Endpoints.Slices.Collections;

public sealed class CollectionService : ICollectionService
{
    private readonly IDataReader<CollectionEntity, CollectionId> _collectionReader;
    private readonly IDataLister<CollectionEntity, ProjectId> _collectionLister;
    private readonly IDataWriter<Collection> _collectionWriter;

    public CollectionService(
        IDataReaderFactory dataReaderFactory,
        IDataListerFactory dataListerFactory,
        IDataWriterFactory dataWriterFactory)
    {
        _collectionReader = dataReaderFactory.GetReader<CollectionEntity, CollectionId>();
        _collectionLister = dataListerFactory.GetLister<CollectionEntity, ProjectId>();
        _collectionWriter = dataWriterFactory.GetWriter<Collection>();
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

    public Task<Collection> CreateCollection(Collection collection)
    {
        return _collectionWriter.WriteEntity(collection);
    }
}
