namespace AsyncFlows.Modules.Extensions;

public static class TimeSpans
{
    public static TimeSpan TotalDuration(this TimeSpan[] timeSpans)
        => timeSpans.Aggregate(TimeSpan.Zero, (t1, t2) => t1 + t2);

    public static TimeSpan SumTimeSpans<T>(this IEnumerable<T> source, Func<T, TimeSpan> property)
       => source.Aggregate(TimeSpan.Zero, (t1, item) => t1 + property(item));

    public static TimeSpan? ToTimeSpan(this string? str)
        => TimeSpan.TryParse(str, out var x)
        ? x : null;

    public static TimeSpan ToTimeSpan(this string? str, TimeSpan fallback)
        => str.ToTimeSpan() ?? fallback;
}
