using AsyncFlows.Modules.Extensions;
using AsyncFlows.Modules.Hosting;
using AsyncFlows.Modules.Messaging;
using AsyncFlows.Modules.Messaging.Kafka;
using AsyncFlows.Modules.Root.Failures;
using Confluent.Kafka;
using Google.Protobuf;
using Microsoft.Extensions.Logging;

namespace AsyncFlows.Modules.Messaging.Kafka.Sink;

public sealed class KafkaSink<TKey, TValue>
    : ServiceHost
    where TValue : IMessage<TValue>
{
    private readonly IConsumer<TKey, TValue> consumer;
    private readonly IChannelSource<KafkaMessage<TKey, TValue>> source;

    public KafkaSink(
        ILogger<KafkaSink<TKey, TValue>> logger,
        IConsumer<TKey, TValue> consumer,
        IChannelSource<KafkaMessage<TKey, TValue>> source)
        : base(logger)
    {
        this.consumer = consumer.NotNull();
        this.source = source.NotNull();
    }

    public override async Task ExecuteAsync(CancellationToken cancelToken)
    {
        while (cancelToken.IsNotCanceled())
        {
            await Task.Yield();
            try
            {
                await ConsumeAsync(cancelToken);
            }
            catch (FailureException ex)
            {
                logger.LogWarning("{Service} Consume caught FailureException {@Exception}", ServiceName, ex);
            }
        }
    }

    private async Task ConsumeAsync(CancellationToken cancelToken)
    {
        var result = consumer.Consume(cancelToken);
        if (result.IsPartitionEOF) return;

        var envelope = PackageEnvelope(result);
        await source.SendAsync(envelope, cancelToken);

        await MonitorEnvelope(envelope);
    }

    private Envelope<KafkaMessage<TKey, TValue>> PackageEnvelope(ConsumeResult<TKey, TValue> result)
        => result.ToKafkaPayload()
            .ToEnvelope(TimeSpan.FromSeconds(30),
                () => consumer.CommitAsync(result),
                () => Task.CompletedTask);

    private async Task MonitorEnvelope(Envelope<KafkaMessage<TKey, TValue>> envelope)
    {
        await envelope;
        if (envelope.Failure is null) return;
        logger.LogInformation("{Service} Message failed due to exception {@Message} {@Exception}", ServiceName, envelope.Payload, envelope.Failure);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            consumer?.Dispose();
        base.Dispose(disposing);
    }
}
