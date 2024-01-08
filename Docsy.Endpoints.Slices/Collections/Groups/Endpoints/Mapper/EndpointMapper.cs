using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Persistence.Entities;
using Docsy.Endpoints.Slices.Schemas.Mapper;
using Riok.Mapperly.Abstractions;

namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Mapper;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
[UseStaticMapper(typeof(SchemaMapper))]
internal static partial class EndpointMapper
{
    internal static partial Endpoint Map(EndpointEntity source);
    internal static partial void Map(Endpoint source, Endpoint target);
    private static partial EndpointParameters Map(EndpointParametersEntity source);
    private static partial Parameter Map(EndpointParameterEntity source);
    private static EndpointId MapEndpointId(string source) => EndpointId.FromName(source);
}
