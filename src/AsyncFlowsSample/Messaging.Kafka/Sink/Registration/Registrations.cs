using AsyncFlows.Modules.Messaging;
using AsyncFlows.Modules.Messaging.Kafka;
using AsyncFlows.Modules.Messaging.Kafka.Sink;
using AsyncFlows.Modules.Messaging.Kafka.Sink.Registration;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AsyncFlows.Modules.Registrations;

public static partial class Registrations
{
    public static IKafkaSinkBuilder AddKafkaSink<TKey, TValue>(
        this IServiceCollection services,
        IConfigurationSection saslConfig,
        IConfigurationSection consumerConfig)
        where TValue : class, IMessage<TValue>, new()
        => services.AddSingleton<IHostedService, KafkaSink<TKey, TValue>>()
            .AddMsgChannel<KafkaMessage<TKey, TValue>>()
            .CreateSinkBuilder<TKey, TValue>(saslConfig, consumerConfig);

    private static IKafkaSinkBuilder CreateSinkBuilder<TKey, TValue>(
        this IServiceCollection services,
        IConfigurationSection saslConfig,
        IConfigurationSection consumerConfig)
        where TValue : class, IMessage<TValue>, new()
        => new KafkaSinkBuilder<TKey, TValue>(services, saslConfig, consumerConfig);
}
