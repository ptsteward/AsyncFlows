using AsyncFlows.Modules.Messaging.Kafka;
using Confluent.Kafka;
using Google.Protobuf;

namespace AsyncFlows.Modules.Messaging.Kafka.Sink;

public static class Extensions
{
    internal static KafkaMessage<TKey, TValue> ToKafkaPayload<TKey, TValue>(
        this ConsumeResult<TKey, TValue> result)
        where TValue : IMessage<TValue>
    {
        var message = result.Message;
        var metadata = message.Headers.ToMetadata();
        var key = message.Key;
        var value = message.Value;
        return new(key, value, metadata);
    }

    internal static Task CommitAsync<TKey, TValue>(
        this IConsumer<TKey, TValue> consumer,
        ConsumeResult<TKey, TValue> result)
    {
        consumer.Commit(result);
        return Task.CompletedTask;
    }
}
