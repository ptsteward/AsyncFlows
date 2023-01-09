using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using static System.Net.HttpStatusCode;

namespace AsyncFlows.Modules.Root.Failures;

[DebuggerStepThrough]
public static class Extensions
{
    public static T ThrowsFailure<T>(this Func<T> inner,
        HttpStatusCode failCode = InternalServerError,
        string? message = default,
        [CallerArgumentExpression("inner")] string? expr = default)
    {
        try
        {
            return inner();
        }
        catch (Exception ex)
        {
            throw ToFailure(failCode, message, expr)
                .ToException(ex);
        }
    }

    public static async Task<T> ThrowsAsyncFailure<T>(this Func<Task<T>> inner,
        HttpStatusCode failCode = InternalServerError,
        string? message = default,
        [CallerArgumentExpression("inner")] string? expr = default)
    {
        try
        {
            return await inner();
        }
        catch (Exception ex)
        {
            throw ToFailure(failCode, message, expr)
                .ToException(ex);
        }
    }

    public static void ThrowsFailure(this Action inner,
        HttpStatusCode failCode = InternalServerError,
        string? message = default,
        [CallerArgumentExpression("inner")] string? expr = default)
    {
        try
        {
            inner();
        }
        catch (Exception ex)
        {
            throw ToFailure(failCode, message, expr)
                .ToException(ex);
        }
    }

    public static async Task ThrowsAsyncFailure(this Func<Task> inner,
        HttpStatusCode failCode = InternalServerError,
        string? message = default,
        [CallerArgumentExpression("inner")] string? expr = default)
    {
        try
        {
            await inner();
        }
        catch (Exception ex)
        {
            throw ToFailure(failCode, message, expr)
                .ToException(ex);
        }
    }

    private static FailureException ToException(this Failure failure,
        Exception ex)
        => new FailureException(failure, ex);

    private static Failure ToFailure(
        HttpStatusCode failCode = InternalServerError,
        string? message = default,
        string? expr = default)
        => new Failure(failCode, message, expr);
}