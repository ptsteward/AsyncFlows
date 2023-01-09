using AsyncFlows.Modules.Extensions;
using AsyncFlows.Modules.Messaging.Kafka.Configs;
using AsyncFlows.Modules.Messaging.Kafka.ConfluentBuilders;
using Confluent.Kafka;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncFlows.Modules.Messaging.Kafka.Sink.Registration;

internal class KafkaSinkBuilder<Tk, TValue>
    : IKafkaSinkBuilder
    where TValue : class, IMessage<TValue>, new()
{
    private readonly IServiceCollection services;
    private readonly IConfigurationSection saslConfig;
    private readonly IConfigurationSection consumerConfig;

    public KafkaSinkBuilder(
        IServiceCollection services,
        IConfigurationSection saslConfig,
        IConfigurationSection consumerConfig)

    {
        this.services = services.NotNull();
        this.saslConfig = saslConfig.NotNull();
        this.consumerConfig = consumerConfig.NotNull();
    }

    IServiceCollection IKafkaSinkBuilder.WithStandardKey<TKey>()
    {
        ValidKeyTypeOrThrow<TKey>();
        return services.SetSingleton(()
            => consumerConfig.ReadConsumerConfig(saslConfig)
                .BuildStandardConsumer<TKey, TValue>());
    }

    IServiceCollection IKafkaSinkBuilder.WithComplexKey<TKey>()
    {
        ValidKeyTypeOrThrow<TKey>();
        return services.SetSingleton(()
            => consumerConfig.ReadConsumerConfig(saslConfig)
                .BuildComplexKeyConsumer<TKey, TValue>());
    }

    IServiceCollection IKafkaSinkBuilder.WithNullKey()
    {
        ValidKeyTypeOrThrow<Null>();
        return services.SetSingleton(()
            => consumerConfig.ReadConsumerConfig(saslConfig)
                .BuildNullKeyConsumer<TValue>());
    }

    private void ValidKeyTypeOrThrow<TKey>()
    {
        if (typeof(Tk) != typeof(TKey))
            throw new ArgumentException(
                $"Non-matching key found. Expected: {typeof(Tk).Name} found {typeof(TKey).Name}",
                nameof(TKey));
    }
}
