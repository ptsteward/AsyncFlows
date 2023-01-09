namespace AsyncFlows.Modules.Extensions;

public static class CharArrays
{
    public delegate int IndexFunc<T>(ReadOnlySpan<T> source);

    public delegate int LengthFunc<T>(ReadOnlySpan<T> source);
}
