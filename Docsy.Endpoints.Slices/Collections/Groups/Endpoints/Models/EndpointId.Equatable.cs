namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;

public readonly partial struct EndpointId : IEquatable<EndpointId>
{
    public bool Equals(EndpointId other)
    {
        return Value.Equals(other.Value) && GroupId.Equals(other.GroupId);
    }

    public override bool Equals(object? obj)
    {
        return obj is EndpointId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, GroupId);
    }

    public static bool operator ==(EndpointId left, EndpointId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(EndpointId left, EndpointId right)
    {
        return !(left == right);
    }
}
