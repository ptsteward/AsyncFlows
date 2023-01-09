using static AsyncFlows.Modules.Extensions.CharArrays;

namespace AsyncFlows.Modules.Extensions;

public static class Strings
{
    public static string Substring(this string input, IndexFunc<char> startAt, LengthFunc<char> length)
        => new(input.AsSpan().Slice(startAt, length));

    public static string SubstringUntil(this string input, LengthFunc<char> length)
        => new(input.AsSpan().Slice(_ => 0, length));

    public static string SubstringUntil(this string input, char thisChar)
        => new(input.AsSpan().Slice(_ => 0, s => s.IndexOrEnd(thisChar)));

    public static string SubstringFrom(this string input, IndexFunc<char> startAt)
        => new(input.AsSpan().Slice(startAt));

    public static string SubstringPast(this string input, IndexFunc<char> pastHere)
        => new(input.AsSpan().Slice(pastHere(input) + 1));

    public static string Join(this IEnumerable<string> values, string separator)
        => string.Join(separator, values);
}
