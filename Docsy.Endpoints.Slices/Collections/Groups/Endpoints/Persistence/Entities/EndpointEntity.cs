using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Persistence.Entities;

internal sealed class EndpointEntity
{
    [BsonElement("_id")]
    public ObjectId Id { get; set; }

    [BsonElement("groupId")]
    public string GroupId { get; set; } = string.Empty;

    [BsonElement("endpointId")]
    public string EndpointId { get; set; } = string.Empty;

    [BsonElement("url")]
    public string Url { get; set; } = string.Empty;

    [BsonElement("httpVerb")]
    public string HttpVerb { get; set; } = string.Empty;

    [BsonElement("parameters")]
    public EndpointParametersEntity Parameters { get; set; } = new();

    [BsonElement("responses")]
    public EndpointResponseEntity[] Responses { get; set; } = Array.Empty<EndpointResponseEntity>();
}
