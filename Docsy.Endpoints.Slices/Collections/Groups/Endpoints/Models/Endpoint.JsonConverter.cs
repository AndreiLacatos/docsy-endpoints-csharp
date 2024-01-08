using System.Text.Json;
using System.Text.Json.Serialization;

namespace Docsy.Endpoints.Slices.Collections.Groups.Endpoints.Models;

public readonly partial struct EndpointId
{
    internal class JsonConverter : JsonConverter<EndpointId>
    {
        public override EndpointId Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            return FromName(reader.GetString()!);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EndpointId value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
