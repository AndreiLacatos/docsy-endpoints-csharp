namespace Docsy.Endpoints.Slices.Collections.Models;

public sealed class CollectionChangeSet
{
    public required CollectionId Target { get; init; }
    public required Collection ChangeSet { get; init; }
    public required string Mode { get; init; }
    public required string RequestKey { get; init; }
}
