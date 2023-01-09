using Confluent.Kafka;
using Confluent.SchemaRegistry;

namespace AsyncFlows.Modules.Messaging.Kafka;

internal static class Constants
{
    public static class MetadataFields
    {
        public static readonly string Name = nameof(Name);
        public static readonly string Version = nameof(Version);
        public static readonly string OccurredOn = nameof(OccurredOn);
        public static readonly string MessageID = nameof(MessageID);
        public static readonly string CorrelationID = nameof(CorrelationID);
        public static readonly string CausationID = nameof(CausationID);
        public static readonly string ClientID = nameof(ClientID);
        public static readonly string UserID = nameof(UserID);
        public static readonly string Origin = nameof(Origin);
    }

    public static class SaslSection
    {
        public static readonly string SaslUsername = nameof(SaslUsername);
        public static readonly string SaslPassword = nameof(SaslPassword);
        public static readonly string SaslMechanism = nameof(SaslMechanism);
        public static readonly string SecurityProtocol = nameof(SecurityProtocol);
        public static readonly string CredentialsSource = nameof(CredentialsSource);
        public static readonly SaslMechanism SaslMechanism_Plain = Confluent.Kafka.SaslMechanism.Plain;
        public static readonly SecurityProtocol SecurityProtocol_SaslSsl = Confluent.Kafka.SecurityProtocol.SaslSsl;
        public static readonly AuthCredentialsSource CredentialsSource_UserInfo = AuthCredentialsSource.UserInfo;
    }

    public static class RegistrySection
    {
        public static readonly string RegistryUrl = nameof(RegistryUrl);
    }

    public static class ConsumerSection
    {
        public static readonly string Topic = nameof(Topic);
        public static readonly string BootstrapServers = nameof(BootstrapServers);
        public static readonly string EnableAutoCommit = nameof(EnableAutoCommit);
        public static readonly string EnableAutopOffsetStore = nameof(EnableAutopOffsetStore);
        public static readonly string GroupId = nameof(GroupId);
        public static readonly string ClientId = nameof(ClientId);
        public static readonly string AutoOffsetReset = nameof(AutoOffsetReset);
        public static readonly string GroupOffsetReset = nameof(GroupOffsetReset);
        public static readonly AutoOffsetReset AutoOffsetReset_Latest = Confluent.Kafka.AutoOffsetReset.Latest;
    }

    public static class ProducerSection
    {
        public static readonly string Topic = nameof(Topic);
        public static readonly string BootstrapServers = nameof(BootstrapServers);
        public static readonly string ClientId = nameof(ClientId);
        public static readonly string Partitioner = nameof(Partitioner);
        public static readonly Partitioner Partitioner_Murmur2 = Confluent.Kafka.Partitioner.Murmur2;
    }
}
