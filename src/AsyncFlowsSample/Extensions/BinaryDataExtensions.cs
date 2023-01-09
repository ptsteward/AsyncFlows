//using Sched.Modules.Extensions;

//namespace Sched.Modules.Extensions;

//public static class BinaryDataExtensions
//{
//    public static T? ToValidatedObject<T>(this BinaryData? data)
//        where T : IValidatableJson<T>
//        => data.ValidatedData<T>() switch
//        {
//            (true, _) => data.ToObjectFromJson<T>(),
//            (false, _) => default
//        };

//    private static (bool isValid, BinaryData data) ValidatedData<T>([NotNull] this BinaryData? data)
//        where T : IValidatableJson<T>
//        => (data.NotNull()
//            .ToMemory()
//            .IsValid<T>(),
//            data);

//}
