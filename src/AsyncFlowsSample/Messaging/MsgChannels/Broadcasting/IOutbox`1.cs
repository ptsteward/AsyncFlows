namespace AsyncFlows.Modules.Messaging.MsgChannels.Broadcasting;

internal interface IOutbox<TPayload> where TPayload : notnull
{
    void Complete();
    Envelope<TPayload> GetEnvelope();
}
