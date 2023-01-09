using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AsyncFlows.Modules.Registrations;

public static partial class Registrations
{
    public static IKafkaSourceBuilder AddKafkaSource<TKey, TValue>(
        this IServiceCollection services,
        IConfigurationSection saslConfig,
        IConfigurationSection producerConfig,
        IConfigurationSection registryConfig)
        where TValue : class, IMessage<TValue>, new()
        => services.AddSingleton<IHostedService, KafkaSource<TKey, TValue>>()
            .AddSchemaRegistry(registryConfig, saslConfig)
            .SetSingleton<GetTopic<TKey, TValue>>(_ =>
                () => producerConfig[ProducerSection.Topic]!)
            .AddMsgChannel<KafkaMessage<TKey, TValue>>()
            .CreateSourceBuilder<TKey, TValue>(saslConfig, producerConfig);

    private static IKafkaSourceBuilder CreateSourceBuilder<TKey, TValue>(
        this IServiceCollection services,
        IConfigurationSection saslConfig,
        IConfigurationSection consumerConfig)
        where TValue : class, IMessage<TValue>, new()
        => new KafkaSourceBuilder<TKey, TValue>(services, saslConfig, consumerConfig);
}
