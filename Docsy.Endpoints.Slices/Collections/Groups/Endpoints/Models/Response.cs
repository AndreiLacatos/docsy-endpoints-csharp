using Docsy.Endpoints.Slices.Schemas.Models;

namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;

public sealed class Response
{
    public required int ResponseCode { get; set; }
    public SchemaId? ResponseBodySchema { get; set; }
}
