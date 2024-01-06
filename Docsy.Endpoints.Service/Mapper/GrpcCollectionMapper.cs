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
    private static string Map(CollectionId source) => source.GetName();
}
