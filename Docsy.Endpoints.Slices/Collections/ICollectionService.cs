using Docsy.Endpoints.Slices.Collections.Models;

namespace Docsy.Endpoints.Slices.Collections;

public interface ICollectionService
{
    public Task<IEnumerable<Collection>> ListProjectCollections(ProjectId projectId);
    public Task<Collection> GetCollection(CollectionId collectionId);
}
