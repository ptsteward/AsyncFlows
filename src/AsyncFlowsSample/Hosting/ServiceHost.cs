using AsyncFlows.Modules.Extensions;
using AsyncFlows.Modules.Root.Abstracts;
using AsyncFlows.Modules.Root.Failures;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AsyncFlows.Modules.Hosting;

public abstract class ServiceHost
    : DisposableBase,
    IHostedService
{
    protected readonly ILogger logger;

    private Task execution = default!;
    private CancellationTokenSource gracefulCancel = default!;

    private string _serviceName = default!;
    protected string ServiceName
        => _serviceName ??= GetType().ClassName();

    protected ServiceHost(ILogger logger)
        => this.logger = logger.NotNull();

    public abstract Task ExecuteAsync(CancellationToken cancelToken);

    public virtual Task StartAsync(CancellationToken cancelToken)
    {
        logger.LogInformation("ServiceHost: {Service} Starting", ServiceName);
        gracefulCancel = new();

        execution = ExecuteAsync(gracefulCancel.Token);

        logger.LogInformation("ServiceHost: {Service} Started", ServiceName);

        if (execution.IsCompleted)
            return execution;
        return Task.CompletedTask;
    }

    public virtual async Task StopAsync(CancellationToken cancelToken)
    {
        logger.LogInformation("ServiceHost: {Service} Stopping", ServiceName);
        var finalization = execution ?? Task.CompletedTask;

        try
        {
            gracefulCancel.Cancel();
            await finalization.WaitAsync(cancelToken);
        }
        catch (FailureException ex)
        {
            logger.LogError("ServiceHost: {Service} Unhandled Failure Exception {@Exception}", ServiceName, ex);
        }
        catch (OperationCanceledException ex) when (ex.CancellationToken != gracefulCancel.Token)
        {
            logger.LogDebug("ServiceHost: {Service} Gracefully Cancelled {@Exception}", ServiceName, ex);
        }
        catch (Exception ex)
        {
            logger.LogError("ServiceHost: {Service} Caught Unhandled Exception {@Exception}", ServiceName, ex);
        }
        finally
        {
            logger.LogInformation("ServiceHost: {Service} Stopped", ServiceName);
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (!disposed && disposing)
        {
            execution?.Dispose();
            gracefulCancel?.Dispose();
        }
        Dispose();
    }
}
