using Docsy.Endpoints.Slices.Collections.Groups.Mapper;
using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Docsy.Endpoints.Slices.Collections.Groups.Persistence.Entities;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Common.Persistence;

namespace Docsy.Endpoints.Slices.Collections.Groups;

public sealed class GroupService : IGroupService
{
    private readonly IDataLister<GroupEntity, CollectionId> _groupLister;
    private readonly IDataReader<Collection, CollectionId> _collectionStageReader;
    private readonly IDataWriter<Collection> _collectionStageWriter;

    public GroupService(
        IDataListerFactory dataListerFactory,
        IDataReaderFactory dataReaderFactory,
        IDataWriterFactory dataWriterFactory)
    {
        _groupLister = dataListerFactory.GetLister<GroupEntity, CollectionId>();
        _collectionStageReader = dataReaderFactory.GetStageReader<Collection, CollectionId>();
        _collectionStageWriter = dataWriterFactory.GetStageWriter<Collection>();
    }

    public async Task<IEnumerable<Group>> GetCollectionGroups(CollectionId collectionId)
    {
        var groups = await _groupLister.ListEntities(collectionId);
        return groups.Select(GroupMapper.Map);
    }

    public async Task<IEnumerable<Group>> GetStagedCollectionGroups(CollectionId collectionId)
    {
        var collection = await _collectionStageReader
            .GetEntityOrDefault(collectionId);
        return collection!.Groups;
    }

    public async Task<Group> CreateGroup(Group group)
    {
        var collection = await _collectionStageReader
            .GetEntityOrDefault(group.GroupId.CollectionId);
        collection!.Groups = new List<Group>(collection.Groups)
        {
            group,
        };
        await _collectionStageWriter.WriteEntity(collection);
        return group;
    }

    public async Task<GroupChangeSet> StageGroupChanges(GroupChangeSet changeSet)
    {
        var stagedCollection = await _collectionStageReader
            .GetEntityOrDefault(changeSet.Target.CollectionId);
        var targetGroup = stagedCollection!.Groups.First(group =>
                group.GroupId == changeSet.Target);
        targetGroup.GroupName = changeSet.ChangeSet.GroupName;
        await _collectionStageWriter.WriteEntity(stagedCollection);
        return changeSet;
    }
}
