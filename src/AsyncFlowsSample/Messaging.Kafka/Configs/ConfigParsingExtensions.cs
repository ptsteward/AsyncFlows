using AsyncFlows.Modules.Extensions;
using Microsoft.Extensions.Configuration;

namespace AsyncFlows.Modules.Messaging.Kafka.Configs;

public static class ConfigParsingExtensions
{
    internal static KafkaRegistryConfig ReadSchemaConfig(
        this IConfigurationSection registry,
        IConfigurationSection sasl)
        => new(
            new(registry[RegistrySection.RegistryUrl]!),
            sasl[SaslSection.CredentialsSource].ToEnum(SaslSection.CredentialsSource_UserInfo),
            sasl[SaslSection.SaslUsername]!,
            sasl[SaslSection.SaslPassword]!);

    internal static KafkaConsumerConfig ReadConsumerConfig(
        this IConfigurationSection consumer,
        IConfigurationSection sasl)
        => new(
            consumer[ConsumerSection.Topic]!,
            consumer[ConsumerSection.ClientId]!,
            consumer[ConsumerSection.GroupId]!,
            consumer[ConsumerSection.BootstrapServers]!,
            consumer[ConsumerSection.EnableAutoCommit].ToBool(false),
            consumer[ConsumerSection.EnableAutopOffsetStore].ToBool(false),
            consumer[ConsumerSection.AutoOffsetReset].ToEnum(ConsumerSection.AutoOffsetReset_Latest),
            consumer[ConsumerSection.GroupOffsetReset].ToBool(false),
            sasl[SaslSection.SaslMechanism].ToEnum(SaslSection.SaslMechanism_Plain),
            sasl[SaslSection.SecurityProtocol].ToEnum(SaslSection.SecurityProtocol_SaslSsl),
            sasl[SaslSection.SaslUsername]!,
            sasl[SaslSection.SaslPassword]!);

    internal static KafkaProducerConfig ReadProducerConfig(
        this IConfigurationSection producer,
        IConfigurationSection sasl)
        => new(
            producer[ProducerSection.Topic]!,
            producer[ProducerSection.ClientId]!,
            producer[ProducerSection.BootstrapServers]!,
            producer[ProducerSection.Partitioner].ToEnum(ProducerSection.Partitioner_Murmur2),
            sasl[SaslSection.SaslMechanism].ToEnum(SaslSection.SaslMechanism_Plain),
            sasl[SaslSection.SecurityProtocol].ToEnum(SaslSection.SecurityProtocol_SaslSsl),
            sasl[SaslSection.SaslUsername]!,
            sasl[SaslSection.SaslPassword]!);
}
