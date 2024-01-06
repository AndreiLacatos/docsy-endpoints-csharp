namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;

public sealed class Endpoint
{
    public required EndpointId EndpointId { get; set; }
    public required string Url { get; set; }
    public required string HttpVerb { get; set; }
    public required EndpointParameters Parameters { get; set; }
    public required IEnumerable<Response> Responses { get; set; }
}
