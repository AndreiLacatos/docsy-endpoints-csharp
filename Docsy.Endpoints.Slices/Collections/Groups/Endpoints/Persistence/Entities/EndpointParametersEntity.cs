using MongoDB.Bson.Serialization.Attributes;

namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Persistence.Entities;

internal sealed class EndpointParametersEntity
{
    [BsonElement("queryParameters")]
    public EndpointParameterEntity[] QueryParameters { get; set; } =
        Array.Empty<EndpointParameterEntity>();

    [BsonElement("routeParameters")]
    public EndpointParameterEntity[] RouteParameters { get; set; } =
        Array.Empty<EndpointParameterEntity>();

    [BsonElement("requestBodySchema")]
    public string? RequestBodySchema { get; set; } = null;
}
