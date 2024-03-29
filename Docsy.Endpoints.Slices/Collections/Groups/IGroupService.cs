using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Docsy.Endpoints.Slices.Collections.Models;

namespace Docsy.Endpoints.Slices.Collections.Groups;

public interface IGroupService
{
    Task<IEnumerable<Group>> GetCollectionGroups(CollectionId collectionId);
    Task<IEnumerable<Group>> GetStagedCollectionGroups(CollectionId collectionId);
    Task<Group> CreateGroup(Group group);
    Task<GroupChangeSet> StageGroupChanges(GroupChangeSet changeSet);
}
