using AsyncFlows.Modules.Extensions;
using AsyncFlows.Modules.Messaging.MsgChannels;
using AsyncFlows.Modules.Messaging.MsgChannels.Broadcasting;

namespace AsyncFlows.Modules.Registrations;

public static class Registrations
{
    public static IServiceCollection AddMsgChannel<TPayload>(this IServiceCollection services)
        where TPayload : notnull
        => services
            .SetSingleton<OutboxFactory<TPayload>>(_
                => (originator, destructor)
                    => new EnvelopeOutbox<TPayload>(originator, destructor))
            .SetSingleton(sp =>
            {
                var source = sp.GetRequiredService<IChannelSource<TPayload>>();
                var linkable = source as ILinkableSource<TPayload>
                    ?? throw new ArgumentException($"Source {source.GetType().Name} must be linkable", nameof(source));
                return linkable.SinkFactory;
            })
            .SetSingleton<IChannelSource<TPayload>, ChannelSource<TPayload>>()
            .AddTransient(sp => sp.GetRequiredService<SinkFactory<TPayload>>().Invoke());
}
