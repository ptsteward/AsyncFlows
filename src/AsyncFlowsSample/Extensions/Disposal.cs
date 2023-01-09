using System.Diagnostics.CodeAnalysis;

namespace AsyncFlows.Modules.Extensions;

public static class Disposal
{
    [return: NotNull]
    public static T ThrowIfDisposed<T>(
      this T? target,
      bool isDisposed)
      => (target, isDisposed) switch
      {
          (_, true) => throw new ObjectDisposedException(typeof(T).Name),
          (null, _) => throw new ObjectDisposedException(typeof(T).Name),
          (not null, false) => target,
      };
}
