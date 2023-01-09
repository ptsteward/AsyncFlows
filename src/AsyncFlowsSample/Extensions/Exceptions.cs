using System.Net;

namespace AsyncFlows.Modules.Extensions;

public static class Exceptions
{
    private static ISet<HttpStatusCode> httpStatusCodeSet
        = new HashSet<HttpStatusCode>(Enum.GetValues<HttpStatusCode>());

    public static IEnumerable<HttpStatusCode> MessageToHttpCode<TException>(this TException exception)
        where TException : notnull, Exception
        => httpStatusCodeSet
            .Where(code
                => exception.Message.Contains(code.ToString(), StringComparison.OrdinalIgnoreCase))
            .DefaultIfEmpty();

    public static bool IsWellKnown(this Exception ex)
        => ex is TimeoutException ||
            ex is OperationCanceledException ||
            ex is InvalidOperationException;

    public static async ValueTask<T> CatchAsyncFallback<T>(
        this Exception ex,
        Func<Exception, IAsyncEnumerable<T>> getFallback)
    {
        T? message;
        var fallback = getFallback(ex).GetAsyncEnumerator();
        message = await fallback.MoveNextAsync() switch
        {
            true => fallback.Current,
            _ => default!
        };
        return message;
    }
}
