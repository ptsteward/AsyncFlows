using Confluent.SchemaRegistry;

namespace AsyncFlows.Modules.Messaging.Kafka.Configs;

internal record struct KafkaRegistryConfig(
    Uri Url,
    AuthCredentialsSource AuthCredentialsSource,
    string SaslUsername,
    string SaslPassword)
{
    public static implicit operator SchemaRegistryConfig(KafkaRegistryConfig config)
        => new()
        {
            Url = config.Url.ToString(),
            BasicAuthCredentialsSource = config.AuthCredentialsSource,
            BasicAuthUserInfo = $"{config.SaslUsername}:{config.SaslPassword}"
        };
}
