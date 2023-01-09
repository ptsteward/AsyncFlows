using System.Collections.ObjectModel;

namespace AsyncFlows.Modules.Extensions;

public static class Dictionaries
{
    public static IReadOnlyDictionary<TKey, TValue> ToReadonly<TKey, TValue>(this IDictionary<TKey, TValue> dict)
        where TKey : notnull
        => new ReadOnlyDictionary<TKey, TValue>(dict);

    public static IDictionary<TKey, TValue> ToWriteable<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dict)
        where TKey : notnull
        => new Dictionary<TKey, TValue>(dict);

    public static IReadOnlyDictionary<TKey, TValue> AddItem<TKey, TValue>(this IDictionary<TKey, TValue> dict, (TKey key, TValue value) item)
        where TKey : notnull
    {
        dict.Add(item.key.NotNull(), item.value.NotNull());
        return dict.ToReadonly();
    }

    public static IReadOnlyDictionary<TKey, TValue> WithItem<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dict, (TKey key, TValue value) item)
        where TKey : notnull => dict.ToWriteable()
            .AddItem(item);

    public static IReadOnlyDictionary<TKey, TValue> RemoveItem<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
        where TKey : notnull
    {
        dict.Remove(key.NotNull());
        return dict.ToReadonly();
    }

    public static IReadOnlyDictionary<TKey, TValue> WithoutItem<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dict, TKey key)
        where TKey : notnull
        => dict.ToWriteable()
            .RemoveItem(key);

    public static IDictionary<TKey, TValue> EmptyWriteable<TKey, TValue>()
        where TKey : notnull
        => new Dictionary<TKey, TValue>();

    public static IReadOnlyDictionary<TKey, TValue> EmptyReadOnly<TKey, TValue>()
        where TKey : notnull
        => EmptyWriteable<TKey, TValue>().ToReadonly();
}
