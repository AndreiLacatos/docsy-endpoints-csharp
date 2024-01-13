using ApiCollection;
using Docsy.Endpoints.Slices.Collections.Models;
using Riok.Mapperly.Abstractions;

namespace Docsy.Endpoints.Mapper;

[Mapper]
internal static partial class GrpcCollectionMapper
{
    [MapperIgnoreSource(nameof(Collection.Groups))]
    [MapProperty(nameof(Collection.CollectionId), nameof(EndpointCollection.Name))]
    internal static partial EndpointCollection Map(Collection source);
    [MapProperty(nameof(EndpointCollection.Name), nameof(Collection.CollectionId))]
    internal static partial Collection Map(EndpointCollection source);
    internal static partial CollectionChangeSet Map(StageCollectionChangeRequest source);
    internal static partial StageCollectionChangeResponse Map(CollectionChangeSet source);
    private static string Map(CollectionId source) => source.GetName();
    private static CollectionId Map(string source) => CollectionId.FromName(source);
}
