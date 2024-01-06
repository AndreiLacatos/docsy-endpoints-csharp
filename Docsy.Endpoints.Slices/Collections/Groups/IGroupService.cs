using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Docsy.Endpoints.Slices.Collections.Models;

namespace Docsy.Endpoints.Slices.Collections.Groups;

public interface IGroupService
{
    Task<IEnumerable<Group>> GetCollectionGroups(CollectionId collectionId);
}
