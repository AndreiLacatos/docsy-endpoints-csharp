namespace Docsy.Endpoints.Slices.Collections.Models;

public readonly partial struct CollectionId : IEquatable<CollectionId>
{
    public bool Equals(CollectionId other)
    {
        return Value.Equals(other.Value) && ProjectId.Equals(other.ProjectId);
    }

    public override bool Equals(object? obj)
    {
        return obj is CollectionId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, ProjectId);
    }

    public static bool operator ==(CollectionId left, CollectionId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(CollectionId left, CollectionId right)
    {
        return !(left == right);
    }
}
