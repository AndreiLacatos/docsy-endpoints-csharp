using System.Text.Json;
using System.Text.Json.Serialization;

namespace Docsy.Endpoints.Slices.Collections.Models;

public readonly partial struct ProjectId
{
    internal class JsonConverter : JsonConverter<ProjectId>
    {
        public override ProjectId Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            return FromName(reader.GetString()!);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ProjectId value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
