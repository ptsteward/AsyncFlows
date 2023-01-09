using Confluent.Kafka;

namespace AsyncFlows.Modules.Messaging.Kafka.Configs;

internal record struct KafkaProducerConfig(
    string Topic,
    string ClientId,
    string BootstrapServers,
    Partitioner Partitioner,
    SaslMechanism SaslMechanism,
    SecurityProtocol SecurityProtocol,
    string SaslUsername,
    string SaslPassword)
{
    public static implicit operator ProducerConfig(KafkaProducerConfig config)
        => new()
        {
            BootstrapServers = config.BootstrapServers,
            ClientId = config.ClientId,
            Partitioner = config.Partitioner,
            SaslMechanism = config.SaslMechanism,
            SecurityProtocol = config.SecurityProtocol,
            SaslUsername = config.SaslUsername,
            SaslPassword = config.SaslPassword
        };
}
