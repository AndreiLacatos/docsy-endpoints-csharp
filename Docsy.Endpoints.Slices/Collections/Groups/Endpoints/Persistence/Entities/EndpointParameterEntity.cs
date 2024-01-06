using MongoDB.Bson.Serialization.Attributes;

namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Persistence.Entities;

internal sealed class EndpointParameterEntity
{
    [BsonElement("parameterName")]
    public string ParameterName { get; set; } = string.Empty;

    [BsonElement("parameterType")]
    public string ParameterType { get; set; } = string.Empty;
}
