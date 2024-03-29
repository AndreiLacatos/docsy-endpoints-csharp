using Docsy.Endpoints.Slices.Collections.Models;

namespace Docsy.Endpoints.Slices.Collections;

public interface ICollectionService
{
    public Task<IEnumerable<Collection>> ListProjectCollections(ProjectId projectId);
    public Task<Collection> GetCollection(CollectionId collectionId);
    public Task<Collection> GetStagedCollection(CollectionId collectionId);
    public Task<Collection> CreateCollection(Collection collection);
    public Task<CollectionChangeSet> StageCollectionChange(CollectionChangeSet changeSet);
}
