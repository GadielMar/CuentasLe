using System.Text.Json;
using System.Text.Json.Serialization;

namespace BC.Shared.HandlerJsonSerialized;
public class UpperTrimConverter : JsonConverter<string>
{
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Todo lo que entra por JSON se va a UPPER y TRIM
        return reader.GetString()?.Trim().ToUpper();
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}
