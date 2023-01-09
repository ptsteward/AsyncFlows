using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace AsyncFlows.Modules.Extensions;

public static class Nullability
{
    [return: NotNull]
    public static T NotNull<T>([NotNull] this T? item,
        string? message = default,
        [CallerArgumentExpression("item")] string? argName = default)
        => item ?? throw new ArgumentNullException(argName, message);

    [return: NotNull]
    public static async Task<T> NotNull<T>([NotNull] this Task<T?> item,
        string? message = default,
        [CallerArgumentExpression("item")] string? argName = default)
        => await item ?? throw new ArgumentNullException(argName, message);

    [return: NotNull]
    public static IEnumerable<T> YieldNotNull<T>([NotNull] this IEnumerable<T?> items)
    {
        foreach (var item in items)
        {
            if (item is not null)
                yield return item;
            continue;
        }
    }

    [return: NotNull]
    public static async IAsyncEnumerable<T> YieldNotNull<T>([NotNull] this IAsyncEnumerable<T?> items,
        [EnumeratorCancellation] CancellationToken cancelToken)
    {
        await foreach (var item in items.WithCancellation(cancelToken))
        {
            if (item is not null)
                yield return item;
            continue;
        }
    }
}
