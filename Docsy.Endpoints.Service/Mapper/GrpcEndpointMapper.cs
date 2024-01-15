using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;
using Docsy.Endpoints.Slices.Schemas.Models;
using Riok.Mapperly.Abstractions;

namespace Docsy.Endpoints.Mapper;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
internal static partial class GrpcEndpointMapper
{
    [MapProperty(
        nameof(Slices.Collections.Groups.Endpoints.Models.Endpoint.EndpointId),
        nameof(ApiCollection.Endpoint.Name))]
    internal static partial ApiCollection.Endpoint Map(
        Slices.Collections.Groups.Endpoints.Models.Endpoint source);

    [MapProperty(
        nameof(ApiCollection.Endpoint.Name),
        nameof(Slices.Collections.Groups.Endpoints.Models.Endpoint.EndpointId))]
    internal static partial Slices.Collections.Groups.Endpoints.Models.Endpoint Map(
        ApiCollection.Endpoint source);

    internal static partial ChangeSetType MapChangeSetType(string source);
    private static string Map(SchemaId? source) =>
        source?.GetName() ?? string.Empty;
    private static SchemaId? Map(string? source) =>
        string.IsNullOrWhiteSpace(source) ? null : SchemaId.FromName(source);
    private static EndpointId MapEndpointId(string source) =>
        EndpointId.FromName(source);
    private static string MapEndpointId(EndpointId source) => source.ToString();
}
