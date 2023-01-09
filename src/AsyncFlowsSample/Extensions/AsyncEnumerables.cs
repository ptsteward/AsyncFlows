using System.Runtime.CompilerServices;

namespace AsyncFlows.Modules.Extensions;

public static class AsyncEnumerables
{
    public static async IAsyncEnumerable<T> SafeAsyncMoveNext<T>(
        this IAsyncEnumerator<T> enumerator,
        Func<Exception, bool> canHandle,
        Func<Exception, IAsyncEnumerable<T>> onHandle,
        [EnumeratorCancellation] CancellationToken cancelToken = default)
    {
        var msgSet = true;
        while (cancelToken.IsNotCanceled() && msgSet)
        {
            T? message = default!;
            try
            {
                var isMore = await enumerator.MoveNextAsync(cancelToken);
                if (isMore)
                    message = enumerator.Current;
                else
                    msgSet = false;
            }
            catch (Exception ex) when (canHandle(ex))
            {
                message = await ex.CatchAsyncFallback(onHandle);
            }
            cancelToken.ThrowIfCancellationRequested();
            if (msgSet)
                yield return message;
            else
                yield break;
        }
    }
}
