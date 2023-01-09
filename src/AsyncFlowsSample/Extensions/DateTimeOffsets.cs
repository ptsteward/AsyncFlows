namespace AsyncFlows.Modules.Extensions;

public static class DateTimeOffsets
{
    public static DateTimeOffset Next(this DateTimeOffset now, DayOfWeek target)
        => now.AddDays(now.DaysUntilNext(target));

    public static DateTimeOffset At(this DateTimeOffset now, TimeOnly time)
        => now.ToTheDay().Add(time.ToTimeSpan());

    public static DateTimeOffset Truncate(this DateTimeOffset offset, TimeSpan resolution)
        => new DateTimeOffset(offset.Ticks - offset.Ticks % resolution.Ticks, offset.Offset);

    private static int DaysUntilNext(this DateTimeOffset now, DayOfWeek target)
        => (target - now.Tomorrow().DayOfWeek + 7) % 7;

    private static DateTimeOffset ToTheDay(this DateTimeOffset now)
        => now.Truncate(TimeSpan.FromDays(1));

    public static DateTimeOffset Tomorrow(this DateTimeOffset now)
        => now.AddDays(1);
}
