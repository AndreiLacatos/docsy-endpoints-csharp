using Docsy.Endpoints.Slices.Collections.Groups.Mapper;
using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Docsy.Endpoints.Slices.Collections.Groups.Persistence.Entities;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Common.Persistence;

namespace Docsy.Endpoints.Slices.Collections.Groups;

public sealed class GroupService : IGroupService
{
    private readonly IDataLister<GroupEntity, CollectionId> _groupLister;

    public GroupService(IDataListerFactory dataListerFactory)
    {
        _groupLister = dataListerFactory.GetLister<GroupEntity, CollectionId>();
    }

    public async Task<IEnumerable<Group>> GetCollectionGroups(CollectionId collectionId)
    {
        var groups = await _groupLister.ListEntities(collectionId);
        return groups.Select(GroupMapper.Map);
    }
}
