using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Docsy.Endpoints.Slices.Collections.Groups.Persistence.Entities;
using Riok.Mapperly.Abstractions;

namespace Docsy.Endpoints.Slices.Collections.Groups.Mapper;

[Mapper]
internal static partial class GroupMapper
{
    internal static partial Group Map(GroupEntity source);

    private static GroupId Map(string source) => GroupId.FromName(source);
}
