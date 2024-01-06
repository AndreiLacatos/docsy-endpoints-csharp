namespace Docsy.Endpoints.Slices.Schemas.Models;

public sealed class Schema
{
    public required SchemaId SchemaId { get; set; }
    public required string SchemaName { get; set; }
    public required IEnumerable<SchemaEntry> SchemaEntries { get; set; }
        = Enumerable.Empty<SchemaEntry>();
}
