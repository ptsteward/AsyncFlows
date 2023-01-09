using System.Runtime.CompilerServices;

namespace AsyncFlows.Modules.Extensions;

public static class Attempting
{
    public static async ValueTask<TReturn> Attempt<TReturn>(
        this Func<ValueTask<TReturn>> func,
        Func<Exception, ValueTask<TReturn>> onError,
        Func<Exception, bool>? canHandle = default)
    {
        try
        {
            return await func();
        }
        catch (Exception ex)
        when (canHandle?.Invoke(ex) ?? ex.IsWellKnown())
        {
            return await onError(ex);
        }
    }

    public static IAsyncEnumerable<T> Attempt<T>(
        this Func<IAsyncEnumerable<T>> iterator,
        Func<Exception, bool>? canHandle = default,
        Func<Exception, IAsyncEnumerable<T>>? onHandle = default)
    {
        var shouldCatch = canHandle ?? (ex => ex.IsWellKnown());
        var onCatch = onHandle ?? (ex => AsyncEnumerable.Empty<T>());
        var enumerator = iterator().GetAsyncEnumerator();
        return enumerator.SafeAsyncMoveNext(shouldCatch, onCatch);
    }
}
