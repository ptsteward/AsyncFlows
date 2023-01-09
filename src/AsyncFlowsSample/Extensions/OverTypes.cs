namespace AsyncFlows.Modules.Extensions;

public static class OverTypes
{
    public static async Task<U?> AsyncMap<T, U>(this Task<T?> input, Func<T?, U?> map)
        => map(await input);

    public static async Task<U?> AsyncMap<T, U>(this Task<T?> input, Func<T?, Task<U?>> map)
        => await map(await input);

    public static TOutput? ToExpected<TInput, TOutput>(this TInput? input)
        => input is TOutput output
        ? output
        : throw new InvalidOperationException($"Unexpected type recevied - Expected: {typeof(TOutput).Name} but Recevied {typeof(TInput).Name}");
}
