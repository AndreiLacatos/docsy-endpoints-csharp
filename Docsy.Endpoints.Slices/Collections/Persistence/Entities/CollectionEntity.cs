using Docsy.Endpoints.Slices.Collections.Groups.Persistence.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Docsy.Endpoints.Slices.Collections.Persistence.Entities;

internal sealed class CollectionEntity
{
    [BsonElement("_id")]
    public ObjectId Id { get; set; }

    [BsonElement("projectId")]
    public string ProjectId { get; set; } = string.Empty;

    [BsonElement("collectionId")]
    public string CollectionId { get; set; } = string.Empty;

    [BsonElement("collectionName")]
    public string CollectionName { get; set; } = string.Empty;

    [BsonElement("description")]
    public string Description { get; set; } = string.Empty;

    [BsonElement("version")]
    public string Version { get; set; } = string.Empty;

    [BsonElement("groups")]
    public GroupEntity[] Groups { get; set; } = Array.Empty<GroupEntity>();
}
