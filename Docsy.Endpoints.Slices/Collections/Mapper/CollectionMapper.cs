using Docsy.Endpoints.Slices.Collections.Groups.Mapper;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Collections.Persistence.Entities;
using Riok.Mapperly.Abstractions;

namespace Docsy.Endpoints.Slices.Collections.Mapper;

[Mapper]
[UseStaticMapper(typeof(GroupMapper))]
internal static partial class CollectionMapper
{
    internal static partial Collection Map(CollectionEntity source);
    [MapProperty(nameof(@Collection.CollectionId.ProjectId), nameof(CollectionEntity.ProjectId))]
    internal static partial CollectionEntity Map(Collection source);
    internal static partial void Map(Collection source, Collection target);
    private static CollectionId Map(string source) =>
        CollectionId.FromName(source);
    private static string Map(CollectionId source) =>
        source.GetName();
    private static string Map(ProjectId source) =>
        source.GetName();
}
