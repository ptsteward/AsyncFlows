using System.Text;

namespace AsyncFlows.Modules.Extensions;

public static class Types
{
    public static string ClassName<T>(this T instance)
        => instance?.GetType().ClassName() ?? string.Empty;

    public static string ClassName(this Type type)
        => new StringBuilder()
            .Append(type.PlainClassName())
            .AppendTypeArgs(type)
            .ToString();

    private static StringBuilder AppendTypeArgs(this StringBuilder sb, Type type)
        => type.ContainsGenericParameters
            ? sb.Append(
                sb.AppendTypeNames(
                    type.GenericArgumentNames()))
            : sb;

    private static StringBuilder AppendTypeNames(this StringBuilder sb, string typeArgNames)
        => sb.Append('<')
            .Append(typeArgNames)
            .Append('>');

    public static string PlainClassName(this Type type)
        => type.Name.SubstringUntil('`');

    public static string GenericArgumentNames(this Type type)
        => type.GetGenericArguments()
            .Select(arg => arg.PlainClassName())
            .Join(", ");

    public static bool IsSimpleType(this Type type)
        => type.IsPrimitive || type.IsValueType || type == typeof(string);
}
