namespace Docsy.Endpoints.Slices.Collections.Groups.Models;

public readonly partial struct GroupId : IEquatable<GroupId>
{
    public bool Equals(GroupId other)
    {
        return Value.Equals(other.Value) && CollectionId.Equals(other.CollectionId);
    }

    public override bool Equals(object? obj)
    {
        return obj is GroupId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, CollectionId);
    }

    public static bool operator ==(GroupId left, GroupId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(GroupId left, GroupId right)
    {
        return !(left == right);
    }
}
