using Xunit.Sdk;

namespace AsyncFlows.Modules.Messaging.Tests.Common;

public static class Asserts
{
    public static void Pass() { }

    public static void Fail(string? message = default)
        => throw new XunitException(message);
}
