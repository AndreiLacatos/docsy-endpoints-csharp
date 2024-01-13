namespace Docsy.Endpoints.Slices.Collections.Groups.Models;

public sealed class GroupChangeSet
{
    public required GroupId Target { get; init; }
    public required Group ChangeSet { get; init; }
    public required string Mode { get; init; }
    public required string RequestKey { get; init; }
}
