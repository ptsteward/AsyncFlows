using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

namespace AsyncFlows.Modules.Extensions;

public static class Dataflows
{
    public static bool IsCompleted(this IDataflowBlock block)
        => block?.Completion.IsCompleted ?? true;

    public static bool IsNotCompleted(this IDataflowBlock block)
        => !block?.IsCompleted() ?? false;

    public static Func<ValueTask<bool>> OfferAsync<T>(
        this ITargetBlock<T> block,
        T message,
        TimeSpan timeout,
        CancellationToken cancelToken)
        where T : notnull
        => async () =>
        {
            var submitted = false;
            while (!submitted && block.IsNotCompleted())
            {
                cancelToken.ThrowIfCancellationRequested();
                submitted = await block.SendAsync(message, cancelToken)
                    .WaitAsync(timeout, cancelToken);
                await Task.Yield();
            }
            return submitted;
        };

    public static Func<IAsyncEnumerable<T>> EnumerateSource<T>(
        this ISourceBlock<T> source,
        CancellationToken cancelToken)
        => () => Enumeration(source, cancelToken);

    private static async IAsyncEnumerable<T> Enumeration<T>(
        ISourceBlock<T> source,
        [EnumeratorCancellation] CancellationToken cancelToken)
    {
        while (source.IsNotCompleted() && await source.OutputAvailableAsync(cancelToken))
            yield return await source.ReceiveAsync(cancelToken);
        CloseOutEnumeration(source, cancelToken);
    }

    private static void CloseOutEnumeration<TSchema>(
        ISourceBlock<TSchema> source,
        CancellationToken cancelToken)
    {
        if (source.IsCompleted())
            throw new InvalidOperationException($"{nameof(IsCompleted)}");
        cancelToken.ThrowIfCancellationRequested();
    }
}
