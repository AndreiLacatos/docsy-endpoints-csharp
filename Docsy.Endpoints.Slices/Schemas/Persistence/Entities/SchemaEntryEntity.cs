using MongoDB.Bson.Serialization.Attributes;

namespace Docsy.Endpoints.Slices.Schemas.Persistence.Entities;

internal sealed class SchemaEntryEntity
{
    [BsonElement("entryName")]
    public string EntryName { get; set; } = string.Empty;

    [BsonElement("entryType")]
    public string EntryType { get; set; } = string.Empty;

    [BsonElement("schemaReference")]
    public string? SchemaReference { get; set; } = null;

    [BsonElement("isArray")]
    public bool IsArray { get; set; }
}
