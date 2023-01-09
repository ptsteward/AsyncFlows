namespace AsyncFlows.Modules.Extensions;

public static class Enums
{
    public static TEnum ToEnum<TEnum>(this string? value)
        where TEnum : struct
        => value.ToEnum<TEnum>(default);

    public static TEnum ToEnum<TEnum>(this string? value, TEnum fallback)
        where TEnum : struct
        => Enum.TryParse<TEnum>(value, ignoreCase: true, out var enumValue) ? enumValue : fallback;

    public static string? ToQueryParam<TEnum>(this TEnum value)
        where TEnum : Enum
        => $"{value}".ToLower() switch
        {
            "unknown" => null,
            var str => str
        };
}
