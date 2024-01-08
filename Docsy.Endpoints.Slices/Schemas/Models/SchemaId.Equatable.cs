namespace Docsy.Endpoints.Slices.Schemas.Models;

public readonly partial struct SchemaId : IEquatable<SchemaId>
{
    public bool Equals(SchemaId other)
    {
        return Value.Equals(other.Value) && CollectionId.Equals(other.CollectionId);
    }

    public override bool Equals(object? obj)
    {
        return obj is SchemaId other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value, CollectionId);
    }

    public static bool operator ==(SchemaId left, SchemaId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(SchemaId left, SchemaId right)
    {
        return !(left == right);
    }
}
