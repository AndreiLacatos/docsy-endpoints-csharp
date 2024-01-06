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

    private static CollectionId Map(string source) =>
        CollectionId.FromName(source);
}
