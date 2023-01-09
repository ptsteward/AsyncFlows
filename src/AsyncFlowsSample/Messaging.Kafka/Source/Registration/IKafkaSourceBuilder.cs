using Confluent.Kafka;
using Google.Protobuf;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncFlows.Modules.Messaging.Kafka.Source.Registration;

public interface IKafkaSourceBuilder
{
    /// <summary>
    /// Adds the underlying Confluent Kafka producer w/ known Key and Value types
    /// and exercises a runtime check to ensure <typeparamref name="TKey"/> matches w/ Sink
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <returns><see cref="IServiceCollection"/></returns>
    IServiceCollection WithStandardKey<TKey>();

    /// <summary>
    /// Adds the underlying Confluent Kafka producer w/ known Key and Value types
    /// and exercises a runtime check to ensure <typeparamref name="TKey"/> matches w/ Sink
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <returns><see cref="IServiceCollection"/></returns>
    IServiceCollection WithComplexKey<TKey>()
        where TKey : class, IMessage<TKey>, new();

    /// <summary>
    /// Adds the underlying Confluent Kafka producer w/ known Key and Value types
    /// and exercises a runtime check to ensure <typeparamref name="TKey"/> matches w/ <see cref="Null"/> Key Sink
    /// </summary>
    /// <returns><see cref="IServiceCollection"/></returns>
    IServiceCollection WithNullKey();
}
