using System.Text.Json;
using Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;
using Docsy.Endpoints.Slices.Collections.Groups.Models;
using Docsy.Endpoints.Slices.Collections.Models;
using Docsy.Endpoints.Slices.Schemas.Models;

namespace Docsy.Endpoints.Slices.Common.Persistence;

internal static class StageJsonSerializerOptions
{
    internal static readonly JsonSerializerOptions SharedOptions = new ()
    {
        Converters =
        {
            new ProjectId.JsonConverter(),
            new SchemaId.JsonConverter(),
            new CollectionId.JsonConverter(),
            new GroupId.JsonConverter(),
            new EndpointId.JsonConverter(),
        },
    };
}
