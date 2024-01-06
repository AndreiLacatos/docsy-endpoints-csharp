namespace Docsy.Endpoints.Slices.Schemas.Models;

public sealed class SchemaEntry
{
    public required string EntryName { get; set; }
    public required EntryType EntryType { get; set; }
    public SchemaId? SchemaReference { get; set; }
    public required bool IsArray { get; set; }
}
