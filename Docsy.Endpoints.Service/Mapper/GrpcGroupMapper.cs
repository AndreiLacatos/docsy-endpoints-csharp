using ApiCollection;
using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Riok.Mapperly.Abstractions;

namespace Docsy.Endpoints.Mapper;

[Mapper]
internal static partial class GrpcGroupMapper
{
    [MapProperty(nameof(Group.GroupId), nameof(CollectionGroup.Name))]
    internal static partial CollectionGroup Map(Group source);
    [MapProperty(nameof(CollectionGroup.Name), nameof(Group.GroupId))]
    internal static partial Group Map(CollectionGroup source);
    internal static partial GroupChangeSet Map(StageGroupChangeRequest source);
    internal static partial StageGroupChangeResponse Map(GroupChangeSet source);
    private static string Map(GroupId source) => source.GetName();
    private static GroupId Map(string source) => GroupId.FromName(source);
}
