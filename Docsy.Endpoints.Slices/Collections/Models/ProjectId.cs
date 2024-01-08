namespace Docsy.Endpoints.Slices.Collections.Models;

public readonly partial struct ProjectId
{
    public Guid Value { get; }

    private ProjectId(Guid value)
    {
        Value = value;
    }

    public static ProjectId FromName(string name)
    {
        return new ProjectId(Guid.Parse(name.Split('/').Last()));
    }

    public static ProjectId FromValue(Guid value)
    {
        return new ProjectId(value);
    }

    public static ProjectId FromValue(string value)
    {
        return new ProjectId(Guid.Parse(value));
    }

    public string GetName() => $"projects/{Value}";

    public static implicit operator Guid(ProjectId projectId) =>
        projectId.Value;
}
