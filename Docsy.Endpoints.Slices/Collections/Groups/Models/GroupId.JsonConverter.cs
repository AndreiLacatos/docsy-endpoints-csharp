using System.Text.Json;
using System.Text.Json.Serialization;

namespace Docsy.Endpoints.Slices.Collections.Groups.Models;

public readonly partial struct GroupId
{
    internal class JsonConverter : JsonConverter<GroupId>
    {
        public override GroupId Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            return FromName(reader.GetString()!);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GroupId value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
