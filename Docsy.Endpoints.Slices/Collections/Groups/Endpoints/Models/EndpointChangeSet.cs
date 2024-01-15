namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;

public sealed class EndpointChangeSet
{
    public required EndpointId EndpointId { get; set; }
    public required Endpoint Endpoint { get; set; }
    public required ChangeSetType Type { get; init; }
}
