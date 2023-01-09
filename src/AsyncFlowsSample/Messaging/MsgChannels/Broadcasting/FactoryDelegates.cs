using AsyncFlows.Modules.Messaging;

namespace AsyncFlows.Modules.Messaging.MsgChannels.Broadcasting;

internal delegate IOutbox<TPayload> OutboxFactory<TPayload>(
    Envelope<TPayload> originator,
    Action<Guid> destructor)
    where TPayload : notnull;

internal delegate IChannelSink<TPayload> SinkFactory<TPayload>()
    where TPayload : notnull;
