using Docsy.Endpoints.Slices.Schemas.Models;
using Docsy.Endpoints.Slices.Schemas.Persistence.Entities;
using Riok.Mapperly.Abstractions;

namespace Docsy.Endpoints.Slices.Schemas.Mapper;

[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName, EnumMappingIgnoreCase = true)]
internal static partial class SchemaMapper
{
    internal static partial Schema Map(SchemaEntity source);
    internal static SchemaId? MapSchemaId(string? source)
    {
        if (string.IsNullOrWhiteSpace(source))
        {
            return null;
        }

        return SchemaId.FromName(source);
    }
    private static partial SchemaEntry Map(SchemaEntryEntity source);
    private static SchemaId Map(string source) => SchemaId.FromName(source);
}
