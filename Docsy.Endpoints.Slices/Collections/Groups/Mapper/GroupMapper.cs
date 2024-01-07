using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Docsy.Endpoints.Slices.Collections.Groups.Persistence.Entities;
using Riok.Mapperly.Abstractions;

namespace Docsy.Endpoints.Slices.Collections.Groups.Mapper;

[Mapper]
internal static partial class GroupMapper
{
    internal static partial Group Map(GroupEntity source);
    internal static partial GroupEntity Map(Group source);

    private static GroupId Map(string source) => GroupId.FromName(source);
    private static string Map(GroupId source) => source.GetName();
}
