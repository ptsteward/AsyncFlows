using Confluent.Kafka;
using Google.Protobuf;
using Microsoft.Extensions.Logging;

namespace AsyncFlows.Modules.Messaging.Kafka.Source;

internal sealed class KafkaSource<TKey, TValue>
    : ServiceHost
    where TValue : IMessage<TValue>
{
    private readonly IProducer<TKey, TValue> producer;
    private readonly IChannelSink<KafkaMessage<TKey, TValue>> source;
    private readonly string topic;

    public KafkaSource(
        ILogger<KafkaSource<TKey, TValue>> logger,
        IProducer<TKey, TValue> producer,
        IChannelSink<KafkaMessage<TKey, TValue>> source,
        GetTopic<TKey, TValue> topic)
        : base(logger)
    {
        this.producer = producer.NotNull();
        this.source = source.NotNull();
        this.topic = topic.NotNull().Invoke();
    }

    public override async Task ExecuteAsync(CancellationToken cancelToken)
    {
        await Task.Yield();
        while (cancelToken.IsNotCanceled())
        {
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
        await foreach (var envelope in source.ConsumeAsync(cancelToken))
        {
            try
            {
                Produce(envelope, cancelToken);
            }
            catch (Exception ex)
            {
                envelope.Fail(ex);
                logger.LogWarning("{Service} Produce caught Unknown {@Exception}", ServiceName, ex);
            }

        }
    }

    private void Produce(
        Envelope<KafkaMessage<TKey, TValue>> envelope,
        CancellationToken cancelToken)
    {
        cancelToken.ThrowIfCancellationRequested();
        (var key, var value, var metadata) = envelope.Payload;
        producer.Produce(topic, new Message<TKey, TValue>()
        {
            Key = key,
            Value = value,
            Headers = metadata.ToHeaders()
        });
        envelope.Complete();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            producer?.Dispose();
        base.Dispose(disposing);
    }
}
