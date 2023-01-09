namespace AsyncFlows.Modules.Extensions;

public static class Tasks
{
    public static Task AsyncWait(this TimeSpan timeout)
        => Task.Delay(timeout);

    public static async Task AsyncWait(this CancellationToken cancelToken)
    {
        while (cancelToken.IsNotCanceled())
            await Task.Yield();
    }

    public static async Task<bool> TryWaitAsync(this Task task, TimeSpan timeout)
    {
        await Task.WhenAny(task, timeout.AsyncWait());
        return task.IsCompletedSuccessfully;
    }
}
