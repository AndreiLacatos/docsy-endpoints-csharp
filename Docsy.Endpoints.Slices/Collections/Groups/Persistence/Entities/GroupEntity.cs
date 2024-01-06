using MongoDB.Bson.Serialization.Attributes;

namespace Docsy.Endpoints.Slices.Collections.Groups.Persistence.Entities;

internal sealed class GroupEntity
{
    [BsonElement("groupId")]
    public string GroupId { get; set; } = string.Empty;

    [BsonElement("groupName")]
    public string GroupName { get; set; } = string.Empty;
}
