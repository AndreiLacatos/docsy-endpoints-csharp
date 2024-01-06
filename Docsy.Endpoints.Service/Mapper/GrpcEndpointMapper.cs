using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;
using Docsy.Endpoints.Slices.Schemas.Models;
using Riok.Mapperly.Abstractions;

namespace Docsy.Endpoints.Mapper;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
internal static partial class GrpcEndpointMapper
{
    internal static partial ApiCollection.Endpoint Map(
        Slices.Collections.Groups.Endpoints.Models.Endpoint source);
    private static string Map(ParameterType source) =>
        source.ToString().ToLower();
    private static string? Map(SchemaId? source) =>
        source?.GetName();
}
