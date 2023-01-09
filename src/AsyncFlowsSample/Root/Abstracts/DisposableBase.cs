namespace AsyncFlows.Modules.Root.Abstracts;

public abstract class DisposableBase
    : IDisposable,
    IAsyncDisposable
{
    protected bool disposed = false;

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();
        Dispose(disposing: false);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
        => disposed = true;

    protected virtual ValueTask DisposeAsyncCore()
    {
        disposed = true;
        return ValueTask.CompletedTask;
    }
}
