using System.Text;
using AsyncFlows.Modules.Messaging.Kafka.Source;
using Confluent.Kafka;

namespace AsyncFlows.Modules.Messaging.Kafka.Source;

public static class ToHeadersExtensions
{
    internal static Headers ToHeaders(this Metadata metadata)
        => new Headers()
            .AttemptAdd(nameof(Name), metadata.Name.ToBytes())
            .AttemptAdd(nameof(MetadataFields.Version), metadata.Version.ToBytes())
            .AttemptAdd(nameof(OccurredOn), metadata.OccurredOn.ToBytes())
            .AttemptAdd(nameof(MessageID), metadata.MessageId.ToBytes())
            .AttemptAdd(nameof(CorrelationID), metadata.CorrelationId.ToBytes())
            .AttemptAdd(nameof(CausationID), metadata.CausationId.ToBytes())
            .AttemptAdd(nameof(ClientID), metadata.ClientId.ToBytes())
            .AttemptAdd(nameof(UserID), metadata.UserId.ToBytes())
            .AttemptAdd(nameof(Origin), metadata.Origin.ToBytes());

    private static Headers AttemptAdd(this Headers headers, string key, byte[]? value)
    {
        if (value is not null)
            headers.Add(key, value);
        return headers;
    }

    private static byte[]? ToBytes(this string? value)
        => value?.Encode();

    private static byte[]? ToBytes(this DateTimeOffset? value)
        => $"{value?.ToUnixTimeMilliseconds()}".ToBytes();

    private static byte[] Encode(this string str)
        => Encoding.UTF8.GetBytes(str);
}
