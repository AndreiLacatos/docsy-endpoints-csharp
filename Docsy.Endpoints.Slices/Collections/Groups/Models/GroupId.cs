using Docsy.Endpoints.Slices.Collections.Models;

namespace Docsy.Endpoints.Slices.Collections.Groups.Models;

public struct GroupId
{
    public Guid Value { get; }

    public CollectionId CollectionId { get; }

    private GroupId(CollectionId collectionId, Guid value)
    {
        CollectionId = collectionId;
        Value = value;
    }

    public static GroupId FromName(string name)
    {
        var parts = name.Split('/').ToList();
        return new GroupId(CollectionId.FromName(string.Join('/', parts[..^2])), Guid.Parse(parts.Last()));
    }

    public static GroupId FromValue(CollectionId collectionId, Guid value)
    {
        return new GroupId(collectionId, value);
    }

    public static GroupId FromValue(CollectionId collectionId, string value)
    {
        return new GroupId(collectionId, Guid.Parse(value));
    }

    public string GetName() => $"{CollectionId.GetName()}/groups/{Value}";

    public override string ToString() => GetName();
}
