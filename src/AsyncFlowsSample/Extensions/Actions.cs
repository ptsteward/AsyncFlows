namespace AsyncFlows.Modules.Extensions;

public static class Actions
{
    public static void WhenTrue(this Func<bool> condition, Action ifTrue)
        => condition().WhenTrue(ifTrue);

    public static void WhenFalse(this Func<bool> condition, Action ifFalse)
        => condition().WhenFalse(ifFalse);

    public static void Switch(this Func<bool> condition, Action ifTrue, Action ifFalse)
        => condition().Switch(ifTrue, ifFalse);

    public static void WhenTrue(this bool condition, Action ifTrue)
    {
        if (condition)
            ifTrue();
    }

    public static void WhenFalse(this bool condition, Action ifFalse)
    {
        if (!condition)
            ifFalse();
    }

    public static void Switch(this bool condition, Action ifTrue, Action ifFalse)
    {
        if (condition)
            ifTrue();
        else
            ifFalse();
    }

    public static async Task AsyncSwitch(this Task<bool> condition, Func<Task> ifTrue, Func<Task> ifFalse)
    {
        if (await condition)
            await ifTrue();
        else
            await ifFalse();
    }
}
