namespace AsyncFlows.Modules.Messaging.MsgChannels.Broadcasting;

internal interface ILinkableSource<TPayload>
    where TPayload : notnull
{
    SinkFactory<TPayload> SinkFactory { get; }
}
