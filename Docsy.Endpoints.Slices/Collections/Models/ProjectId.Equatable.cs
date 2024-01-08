namespace Docsy.Endpoints.Slices.Collections.Models;

public readonly partial struct ProjectId : IEquatable<ProjectId>
{
    public bool Equals(ProjectId other)
    {
        return Value.Equals(other.Value);
    }

    public override bool Equals(object? obj)
    {
        return obj is ProjectId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(ProjectId left, ProjectId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ProjectId left, ProjectId right)
    {
        return !(left == right);
    }
}
