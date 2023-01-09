using Confluent.Kafka;

namespace AsyncFlows.Modules.Messaging.Kafka.Configs;

internal record struct KafkaConsumerConfig(
    string Topic,
    string ClientId,
    string GroupId,
    string BootstrapServers,
    bool EnableAutoCommit,
    bool EnableAutoOffsetStore,
    AutoOffsetReset AutoOffsetReset,
    bool GroupOffsetReset,
    SaslMechanism SaslMechanism,
    SecurityProtocol SecurityProtocol,
    string SaslUsername,
    string SaslPassword)
{

    public static implicit operator ConsumerConfig(KafkaConsumerConfig config)
        => new()
        {
            ClientId = config.ClientId,
            GroupId = config.GroupId,
            BootstrapServers = config.BootstrapServers,
            EnableAutoCommit = config.EnableAutoCommit,
            EnableAutoOffsetStore = config.EnableAutoOffsetStore,
            AutoOffsetReset = config.AutoOffsetReset,
            SaslMechanism = config.SaslMechanism,
            SecurityProtocol = config.SecurityProtocol,
            SaslUsername = config.SaslUsername,
            SaslPassword = config.SaslPassword,
        };

}
