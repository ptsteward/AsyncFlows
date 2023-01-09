using AsyncFlows.Modules.Extensions;
using AsyncFlows.Modules.Messaging.Kafka.Configs;
using AsyncFlows.Modules.Messaging.Kafka.ConfluentBuilders;
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncFlows.Modules.Messaging.Kafka.Source.Registration;

internal class KafkaSourceBuilder<Tk, TValue>
    : IKafkaSourceBuilder
    where TValue : class, IMessage<TValue>, new()
{
    private readonly IServiceCollection services;
    private readonly IConfigurationSection saslConfig;
    private readonly IConfigurationSection producerConfig;

    public KafkaSourceBuilder(
        IServiceCollection services,
        IConfigurationSection saslConfig,
        IConfigurationSection producerConfig)

    {
        this.services = services.NotNull();
        this.saslConfig = saslConfig.NotNull();
        this.producerConfig = producerConfig.NotNull();
    }

    IServiceCollection IKafkaSourceBuilder.WithStandardKey<TKey>()
    {
        ValidKeyTypeOrThrow<TKey>();
        return services.SetSingleton(sp =>
        {
            var registryClient = sp.GetRequiredService<ISchemaRegistryClient>();
            return producerConfig.ReadProducerConfig(saslConfig)
                .BuildStandardProducer<TKey, TValue>(registryClient);
        });
    }

    IServiceCollection IKafkaSourceBuilder.WithComplexKey<TKey>()
    {
        ValidKeyTypeOrThrow<TKey>();
        return services.SetSingleton(sp =>
        {
            var registryClient = sp.GetRequiredService<ISchemaRegistryClient>();
            return producerConfig.ReadProducerConfig(saslConfig)
                .BuildComplexKeyProducer<TKey, TValue>(registryClient);
        });
    }

    IServiceCollection IKafkaSourceBuilder.WithNullKey()
    {
        ValidKeyTypeOrThrow<Null>();
        return services.SetSingleton(sp =>
        {
            var registryClient = sp.GetRequiredService<ISchemaRegistryClient>();
            return producerConfig.ReadProducerConfig(saslConfig)
                .BuildNullKeyProducer<TValue>(registryClient);
        });
    }

    private void ValidKeyTypeOrThrow<TKey>()
    {
        if (typeof(Tk) != typeof(TKey))
            throw new ArgumentException(
                $"Non-matching key found. Expected: {typeof(Tk).Name} found {typeof(TKey).Name}",
                nameof(TKey));
    }
}
