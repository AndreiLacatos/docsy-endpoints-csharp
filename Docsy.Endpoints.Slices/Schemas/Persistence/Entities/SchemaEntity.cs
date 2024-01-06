using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Docsy.Endpoints.Slices.Schemas.Persistence.Entities;

internal sealed class SchemaEntity
{
    [BsonElement("_id")]
    public ObjectId Id { get; set; }

    [BsonElement("collectionId")]
    public string CollectionId { get; set; } = string.Empty;

    [BsonElement("schemaId")]
    public string SchemaId { get; set; } = string.Empty;

    [BsonElement("schemaName")]
    public string SchemaName { get; set; }  = string.Empty;

    [BsonElement("entries")]
    public SchemaEntryEntity[] SchemaEntries { get; set; } =
        Array.Empty<SchemaEntryEntity>();
}
