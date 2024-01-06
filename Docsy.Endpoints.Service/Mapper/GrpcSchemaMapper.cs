using Docsy.Endpoints.Slices.Schemas.Models;
using Riok.Mapperly.Abstractions;

namespace Docsy.Endpoints.Mapper;

[Mapper]
internal static partial class GrpcSchemaMapper
{
    [MapProperty(nameof(Schema.SchemaId), nameof(ApiCollection.Schema.Name))]
    [MapProperty(nameof(Schema.SchemaEntries), nameof(ApiCollection.Schema.Entries))]
    internal static partial ApiCollection.Schema Map(Schema source);
    private static string Map(SchemaId source) => source.GetName();
    private static string Map(EntryType source) => source.ToString().ToLower();
}
