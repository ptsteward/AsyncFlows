using Microsoft.Extensions.Logging;

namespace AsyncFlows.Modules.Extensions;

public static class Loggers
{
    public static Task LogAsyncDebug(this ILogger logger, string? message, params object?[] args)
        => logger.LogAsyncMessage(logger.LogDebug, message, args);

    public static Task LogAsyncInformation(this ILogger logger, string? message, params object?[] args)
        => logger.LogAsyncMessage(logger.LogInformation, message, args);

    public static Task LogAsyncWarning(this ILogger logger, string? message, params object?[] args)
        => logger.LogAsyncMessage(logger.LogWarning, message, args);

    public static Task LogAsyncError(this ILogger logger, string? message, params object?[] args)
        => logger.LogAsyncMessage(logger.LogError, message, args);

    public static Task LogAsyncCritical(this ILogger logger, string? message, params object?[] args)
        => logger.LogAsyncMessage(logger.LogCritical, message, args);

    public static Task LogAsyncMessage(this ILogger logger, Action<string?, object?[]> sendLog, string? message, params object?[] args)
    {
        sendLog(message, args);
        return Task.CompletedTask;
    }
}
