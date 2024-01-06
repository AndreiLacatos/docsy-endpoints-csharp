using MongoDB.Bson.Serialization.Attributes;

namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Persistence.Entities;

internal sealed class EndpointResponseEntity
{
    [BsonElement("responseCode")]
    public int ResponseCode { get; set; }

    [BsonElement("responseBodySchema")]
    public string? ResponseBodySchema { get; set; } = null;
}
