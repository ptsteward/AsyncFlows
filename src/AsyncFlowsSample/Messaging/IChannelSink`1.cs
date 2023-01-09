namespace AsyncFlows.Modules.Messaging;

public interface IChannelSink<TPayload>
    where TPayload : notnull
{
    IAsyncEnumerable<Envelope<TPayload>> ConsumeAsync(CancellationToken cancelToken = default);
}
