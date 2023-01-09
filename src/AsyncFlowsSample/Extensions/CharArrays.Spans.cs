using static AsyncFlows.Modules.Extensions.CharArrays;

namespace AsyncFlows.Modules.Extensions;

public static class Spans
{
    public static ReadOnlySpan<T> Slice<T>(this ReadOnlySpan<T> span, IndexFunc<T> startAt, LengthFunc<T> length)
        => span.Slice(startAt(span), length(span));

    public static ReadOnlySpan<T> Slice<T>(this ReadOnlySpan<T> span, IndexFunc<T> startAt)
        => span.Slice(startAt(span));

    public static int IndexOrEnd(this ReadOnlySpan<char> span, char value)
    {
        var idx = span.IndexOf(value);
        return idx != -1 ? idx : span.Length;
    }
}
