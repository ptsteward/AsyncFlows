using System.Collections.Concurrent;

namespace AsyncFlows.Modules.Extensions;

public static partial class Collections
{
    public static void MaybeAdd<T>(this ConcurrentBag<T> set, T? item)
    {
        if (item is not null)
            set.Add(item);
    }

    public static void MaybeAdd<T>(this ICollection<T> set, T? item)
    {
        if (item is not null)
            set.Add(item);
    }

    public static void MaybeAdd<T>(this IList<T> set, T? item)
    {
        if (item is not null)
            set.Add(item);
    }
}

