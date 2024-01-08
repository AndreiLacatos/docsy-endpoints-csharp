using Docsy.Endpoints.Slices.Collections.Models;

namespace Docsy.Endpoints.Slices.Schemas.Models;

public readonly partial struct SchemaId
{
    public Guid Value { get; }

    public CollectionId CollectionId { get; }

    private SchemaId(CollectionId collectionId, Guid value)
    {
        CollectionId = collectionId;
        Value = value;
    }

    public static SchemaId FromName(string name)
    {
        var parts = name.Split('/').ToList();
        return new SchemaId(CollectionId.FromName(string.Join('/', parts[..^2])), Guid.Parse(parts.Last()));
    }

    public static SchemaId FromValue(CollectionId collectionId, Guid value)
    {
        return new SchemaId(collectionId, value);
    }

    public static SchemaId FromValue(CollectionId collectionId, string value)
    {
        return new SchemaId(collectionId, Guid.Parse(value));
    }

    public static SchemaId MakeNew(CollectionId collectionId) =>
        FromValue(collectionId, Guid.NewGuid());

    public string GetName() => $"{CollectionId.GetName()}/collections/{Value}";

    public override string ToString() => GetName();
}
