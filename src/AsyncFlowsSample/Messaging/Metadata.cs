namespace AsyncFlows.Modules.Messaging;

public record struct Metadata(
    string? Name,
    string? Version,
    DateTimeOffset? OccurredOn,
    string? MessageId,
    string? CorrelationId,
    string? CausationId,
    string? ClientId,
    string? UserId,
    string? Origin);
