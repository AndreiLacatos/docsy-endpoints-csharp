using Docsy.Endpoints.Slices.Collections.Groups.Models;

namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;

public struct EndpointId
{
    public Guid Value { get; }

    public GroupId GroupId { get; }

    private EndpointId(GroupId groupId, Guid value)
    {
        GroupId = groupId;
        Value = value;
    }

    public static EndpointId FromName(string name)
    {
        var parts = name.Split('/').ToList();
        return new EndpointId(GroupId.FromName(string.Join('/', parts[..^2])), Guid.Parse(parts.Last()));
    }

    public static EndpointId FromValue(GroupId groupId, Guid value)
    {
        return new EndpointId(groupId, value);
    }

    public static EndpointId FromValue(GroupId groupId, string value)
    {
        return new EndpointId(groupId, Guid.Parse(value));
    }

    public static EndpointId MakeNew(GroupId groupId) =>
        FromValue(groupId, Guid.NewGuid());

    public string GetName() => $"{GroupId.GetName()}/groups/{Value}";

    public override string ToString() => GetName();
}
