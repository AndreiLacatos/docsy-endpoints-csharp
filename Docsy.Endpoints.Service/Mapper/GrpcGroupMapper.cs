using ApiCollection;
using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Riok.Mapperly.Abstractions;

namespace Docsy.Endpoints.Mapper;

[Mapper]
internal static partial class GrpcGroupMapper
{
    [MapProperty(nameof(Group.GroupId), nameof(CollectionGroup.Name))]
    [MapProperty(nameof(Group.GroupName), nameof(CollectionGroup.GroupName))]
    internal static partial CollectionGroup Map(Group source);
    private static string Map(GroupId source) => source.GetName();
}
