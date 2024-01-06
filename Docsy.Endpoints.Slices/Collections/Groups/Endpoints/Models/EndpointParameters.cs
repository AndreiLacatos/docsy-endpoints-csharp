using Docsy.Endpoints.Slices.Schemas.Models;

namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;

public sealed class EndpointParameters
{
    public IEnumerable<Parameter> QueryParameters { get; set; } = Enumerable.Empty<Parameter>();
    public IEnumerable<Parameter> RouteParameters { get; set; } = Enumerable.Empty<Parameter>();
    public SchemaId? RequestBodySchema { get; set; }
}
