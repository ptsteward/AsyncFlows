using AsyncFlows.Modules.Extensions;
using Confluent.Kafka;
using System.Text;

namespace AsyncFlows.Modules.Messaging.Kafka.Sink;

public static class ToMetadataExtensions
{
    internal static Metadata ToMetadata(this Headers headers)
    {
        var headerSet = headers.ToDictionary();
        return new(
            headerSet[nameof(Name)],
            headerSet[nameof(MetadataFields.Version)],
            headerSet[nameof(OccurredOn)].ToDateTimeOffset(),
            headerSet[nameof(MessageID)],
            headerSet[nameof(CorrelationID)],
            headerSet[nameof(CausationID)],
            headerSet[nameof(ClientID)],
            headerSet[nameof(UserID)],
            headerSet[nameof(Origin)]);
    }

    private static DateTimeOffset ToDateTimeOffset(this string occurredOn)
        => DateTimeOffset.FromUnixTimeMilliseconds(occurredOn.ToLong() ?? 0);

    private static IDictionary<string, string> ToDictionary(this Headers headers)
    {
        var dict = new Dictionary<string, string>();
        foreach (var header in headers)
            dict[header.Key] = header.ParseValue();
        return dict;
    }

    private static string ParseValue(this IHeader header)
    {
        var bytes = header.GetValueBytes();
        return Encoding.UTF8.GetString(bytes);
    }
}
