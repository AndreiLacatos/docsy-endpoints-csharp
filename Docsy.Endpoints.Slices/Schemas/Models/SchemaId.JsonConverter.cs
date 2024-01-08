using System.Text.Json;
using System.Text.Json.Serialization;

namespace Docsy.Endpoints.Slices.Schemas.Models;

public readonly partial struct SchemaId
{
    internal class JsonConverter : JsonConverter<SchemaId>
    {
        public override SchemaId Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            return FromName(reader.GetString()!);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SchemaId value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
