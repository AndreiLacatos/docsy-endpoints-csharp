using System.Text.Json;
using System.Text.Json.Serialization;

namespace Docsy.Endpoints.Slices.Collections.Models;

public readonly partial struct CollectionId
{
    internal class JsonConverter : JsonConverter<CollectionId>
    {
        public override CollectionId Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            return FromName(reader.GetString()!);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CollectionId value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
