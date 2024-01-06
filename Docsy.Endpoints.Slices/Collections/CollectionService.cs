using Docsy.Endpoints.Slices.Collections.Mapper;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Collections.Persistence.Entities;
using Docsy.Endpoints.Slices.Common.Persistence;

namespace Docsy.Endpoints.Slices.Collections;

public sealed class CollectionService : ICollectionService
{
    private readonly IDataReader<CollectionEntity, CollectionId> _collectionReader;
    private readonly IDataLister<CollectionEntity, ProjectId> _collectionLister;

    public CollectionService(
        IDataReaderFactory dataReaderFactory,
        IDataListerFactory dataListerFactory)
    {
        _collectionReader = dataReaderFactory.GetReader<CollectionEntity, CollectionId>();
        _collectionLister = dataListerFactory.GetLister<CollectionEntity, ProjectId>();
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
}
