using Microsoft.Extensions.DependencyInjection;

namespace BC.Shared.HandlerJsonSerialized;
public static class JsonExtensions
{
    public static IMvcBuilder AddSharedJsonOptions(this IMvcBuilder builder)
    {
        return builder.AddJsonOptions(options =>
        {
            // Regla global de la empresa: Todo a UPPER y TRIM
            options.JsonSerializerOptions.Converters.Add(new UpperTrimConverter());
        });
    }
}
