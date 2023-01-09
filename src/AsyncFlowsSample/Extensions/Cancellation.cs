namespace AsyncFlows.Modules.Extensions;
public static class Cancellation
{
    public static bool IsCanceled(this CancellationToken cancelToken)
        => cancelToken.IsCancellationRequested;

    public static bool IsNotCanceled(this CancellationToken cancelToken)
        => !cancelToken.IsCancellationRequested;

    public static bool IsCanceled(this CancellationTokenSource cancelSource)
        => cancelSource.IsCancellationRequested;

    public static bool IsNotCanceled(this CancellationTokenSource cancelSource)
        => !cancelSource.IsCancellationRequested;
}
