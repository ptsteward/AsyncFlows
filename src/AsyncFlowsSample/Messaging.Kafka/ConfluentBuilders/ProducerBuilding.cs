using AsyncFlows.Modules.Messaging.Kafka.Configs;
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using Google.Protobuf;

namespace AsyncFlows.Modules.Messaging.Kafka.ConfluentBuilders;

public static class ProducerBuilding
{
    internal static IProducer<TKey, TValue> BuildStandardProducer<TKey, TValue>(
        this KafkaProducerConfig config,
        ISchemaRegistryClient registryClient)
        where TValue : class, IMessage<TValue>, new()
    {
        ProducerConfig kafkaConfig = config;
        var producer = new ProducerBuilder<TKey, TValue>(kafkaConfig)
            .SetProtobufValueDeserializer(registryClient)
            .Build();
        return producer;
    }

    internal static IProducer<TKey, TValue> BuildComplexKeyProducer<TKey, TValue>(
        this KafkaProducerConfig config,
        ISchemaRegistryClient registryClient)
        where TKey : class, IMessage<TKey>, new()
        where TValue : class, IMessage<TValue>, new()
    {
        ProducerConfig kafkaConfig = config;
        var producer = new ProducerBuilder<TKey, TValue>(kafkaConfig)
            .SetProtobufKeyDeserializer(registryClient)
            .SetProtobufValueDeserializer(registryClient)
            .Build();
        return producer;
    }

    internal static IProducer<Null, TValue> BuildNullKeyProducer<TValue>(
        this KafkaProducerConfig config,
        ISchemaRegistryClient registryClient)
        where TValue : class, IMessage<TValue>, new()
    {
        ProducerConfig kafkaConfig = config;
        var producer = new ProducerBuilder<Null, TValue>(kafkaConfig)
            .SetProtobufValueDeserializer(registryClient)
            .Build();
        return producer;
    }

    private static ProducerBuilder<TKey, TValue> SetProtobufKeyDeserializer<TKey, TValue>(
        this ProducerBuilder<TKey, TValue> builder,
        ISchemaRegistryClient registryClient)
        where TKey : class, IMessage<TKey>, new()
        => builder.SetKeySerializer(new ProtobufSerializer<TKey>(registryClient)
            .AsSyncOverAsync());

    private static ProducerBuilder<TKey, TValue> SetProtobufValueDeserializer<TKey, TValue>(
        this ProducerBuilder<TKey, TValue> builder,
        ISchemaRegistryClient registryClient)
        where TValue : class, IMessage<TValue>, new()
        => builder.SetValueSerializer(new ProtobufSerializer<TValue>(registryClient)
            .AsSyncOverAsync());
}
