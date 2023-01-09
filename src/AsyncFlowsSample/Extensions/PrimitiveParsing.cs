namespace AsyncFlows.Modules.Extensions;

public static class PrimitiveParsing
{
    public static int? ToInt(this string? str)
        => int.TryParse(str, out var x)
        ? x : null;

    public static int ToInt(this string? str, int fallback)
        => str.ToInt() ?? fallback;

    public static double? ToDouble(this string? str)
        => double.TryParse(str, out var x)
        ? x : null;

    public static double ToDouble(this string? str, double fallback)
        => str.ToDouble() ?? fallback;

    public static long? ToLong(this string? str)
        => long.TryParse(str, out var x)
        ? x : null;

    public static long ToLong(this string? str, long fallback)
        => str.ToLong() ?? fallback;

    public static bool? ToBool(this string? str)
        => bool.TryParse(str, out var x)
        ? x : null;

    public static bool ToBool(this string? str, bool fallback)
        => str.ToBool() ?? fallback;
}
