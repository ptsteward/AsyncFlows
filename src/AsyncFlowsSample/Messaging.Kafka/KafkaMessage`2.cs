using Google.Protobuf;

namespace AsyncFlows.Modules.Messaging.Kafka;

public record KafkaMessage<TKey, TValue>(
    TKey Key,
    TValue Value,
    Metadata Metadata)
    where TValue : IMessage<TValue>
{
    public static implicit operator TValue(KafkaMessage<TKey, TValue> payload)
        => payload.Value;
}
