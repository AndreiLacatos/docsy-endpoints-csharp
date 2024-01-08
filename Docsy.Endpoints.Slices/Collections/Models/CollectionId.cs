namespace Docsy.Endpoints.Slices.Collections.Models;

public readonly partial struct CollectionId
{
    public Guid Value { get; }

    public ProjectId ProjectId { get; }

    private CollectionId(ProjectId projectId, Guid value)
    {
        ProjectId = projectId;
        Value = value;
    }

    public static CollectionId FromName(string name)
    {
        var parts = name.Split('/').ToList();
        return new CollectionId(ProjectId.FromName(string.Join('/', parts[0], parts[1])), Guid.Parse(parts.Last()));
    }

    public static CollectionId FromValue(ProjectId projectId, Guid value)
    {
        return new CollectionId(projectId, value);
    }

    public static CollectionId FromValue(ProjectId projectId, string value)
    {
        return new CollectionId(projectId, Guid.Parse(value));
    }

    public static CollectionId MakeNew(ProjectId projectId) =>
        FromValue(projectId, Guid.NewGuid());

    public string GetName() => $"{ProjectId.GetName()}/collections/{Value}";

    public override string ToString() => GetName();
}
