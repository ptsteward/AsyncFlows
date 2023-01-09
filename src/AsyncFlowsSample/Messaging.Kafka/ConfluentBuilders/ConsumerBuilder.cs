using AsyncFlows.Modules.Messaging.Kafka.Configs;
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry.Serdes;
using Google.Protobuf;

namespace AsyncFlows.Modules.Messaging.Kafka.ConfluentBuilders;

public static partial class ConsumerBuilder
{
    internal static IConsumer<TKey, TValue> BuildStandardConsumer<TKey, TValue>(
        this KafkaConsumerConfig config)
        where TValue : class, IMessage<TValue>, new()
    {
        ConsumerConfig kafkaConfig = config;
        var consumer = new ConsumerBuilder<TKey, TValue>(kafkaConfig)
            .SetProtobufValueDeserializer()
            .SetPartitionsWithOffset(config)
            .BuildAndSubscribe(config.Topic);
        return consumer;
    }

    internal static IConsumer<TKey, TValue> BuildComplexKeyConsumer<TKey, TValue>(
        this KafkaConsumerConfig config)
        where TKey : class, IMessage<TKey>, new()
        where TValue : class, IMessage<TValue>, new()
    {
        ConsumerConfig kafkaConfig = config;
        var consumer = new ConsumerBuilder<TKey, TValue>(kafkaConfig)
            .SetProtobufKeyDeserializer()
            .SetProtobufValueDeserializer()
            .SetPartitionsWithOffset(config)
            .BuildAndSubscribe(config.Topic);
        return consumer;
    }

    internal static IConsumer<Null, TValue> BuildNullKeyConsumer<TValue>(
        this KafkaConsumerConfig config)
        where TValue : class, IMessage<TValue>, new()
    {
        ConsumerConfig kafkaConfig = config;
        var consumer = new ConsumerBuilder<Null, TValue>(kafkaConfig)
            .SetProtobufValueDeserializer()
            .SetPartitionsWithOffset(config)
            .BuildAndSubscribe(config.Topic);
        return consumer;
    }

    private static ConsumerBuilder<TKey, TValue> SetProtobufKeyDeserializer<TKey, TValue>(
        this ConsumerBuilder<TKey, TValue> builder)
        where TKey : class, IMessage<TKey>, new()
        => builder.SetKeyDeserializer(new ProtobufDeserializer<TKey>()
            .AsSyncOverAsync());

    private static ConsumerBuilder<TKey, TValue> SetProtobufValueDeserializer<TKey, TValue>(
        this ConsumerBuilder<TKey, TValue> builder)
        where TValue : class, IMessage<TValue>, new()
        => builder.SetValueDeserializer(new ProtobufDeserializer<TValue>()
            .AsSyncOverAsync());

    private static ConsumerBuilder<TKey, TValue> SetPartitionsWithOffset<TKey, TValue>(
        this ConsumerBuilder<TKey, TValue> builder,
        KafkaConsumerConfig config)
        => builder.SetPartitionsAssignedHandler(
            (consumer, partitions) => config switch
            {
                { GroupOffsetReset: true } => partitions.WithOffset(Offset.Beginning),
                _ => partitions.WithOffset(Offset.Stored)
            });

    private static IEnumerable<TopicPartitionOffset> WithOffset(
        this IEnumerable<TopicPartition> topicPartitions,
        Offset offset)
        => topicPartitions.Select(tp => tp.WithOffset(offset));

    private static TopicPartitionOffset WithOffset(
        this TopicPartition topicPartition,
        Offset offset)
        => new(topicPartition, offset);

    private static IConsumer<TKey, TValue> BuildAndSubscribe<TKey, TValue>(
        this ConsumerBuilder<TKey, TValue> builder,
        string topic)
    {
        var consumer = builder.Build();
        consumer.Subscribe(topic);
        return consumer;
    }
}
