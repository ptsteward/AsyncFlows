using AsyncFlows.Modules.Extensions;
using AsyncFlows.Modules.Messaging.Kafka.Configs;
using Confluent.SchemaRegistry;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncFlows.Modules.Registrations;

public static partial class Registrations
{
    public static IServiceCollection AddSchemaRegistry(
        this IServiceCollection services,
        IConfigurationSection registryConfig,
        IConfigurationSection saslConfig)
        => registryConfig.ReadSchemaConfig(saslConfig)
            .AddRegistryClient(services);

    private static IServiceCollection AddRegistryClient(
        this KafkaRegistryConfig config,
        IServiceCollection services)
    {
        SchemaRegistryConfig kafkaConfig = config;
        return services.SetSingleton<ISchemaRegistryClient>(_ 
            => new CachedSchemaRegistryClient(kafkaConfig));
    }
}
