using Docsy.Endpoints.Slices.Collections.Models;

namespace Docsy.Endpoints.Slices.Schemas.Models;

public struct SchemaId
{
    public Guid Value { get; }

    public ProjectId ProjectId { get; }

    private SchemaId(ProjectId projectId, Guid value)
    {
        ProjectId = projectId;
        Value = value;
    }

    public static SchemaId FromName(string name)
    {
        var parts = name.Split('/').ToList();
        return new SchemaId(ProjectId.FromName(string.Join('/', parts[0], parts[1])), Guid.Parse(parts.Last()));
    }

    public static SchemaId FromValue(ProjectId projectId, Guid value)
    {
        return new SchemaId(projectId, value);
    }

    public static SchemaId FromValue(ProjectId projectId, string value)
    {
        return new SchemaId(projectId, Guid.Parse(value));
    }

    public static SchemaId MakeNew(ProjectId projectId) =>
        FromValue(projectId, Guid.NewGuid());

    public string GetName() => $"{ProjectId.GetName()}/collections/{Value}";

    public override string ToString() => GetName();
}
