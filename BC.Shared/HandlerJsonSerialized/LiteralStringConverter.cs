using System.Text.Json;
using System.Text.Json.Serialization;

namespace BC.Shared.HandlerJsonSerialized;
public class LiteralStringConverter : JsonConverter<string>
{
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Devuelve el string tal cual viene en el JSON
        return reader.GetString();
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}
