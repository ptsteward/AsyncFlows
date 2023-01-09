namespace AsyncFlows.Modules.Messaging;

public static class Constants
{
    public static class MetadataFields
    {
        public static readonly string Name = nameof(Name);
        public static readonly string Version = nameof(Version);
        public static readonly string OccurredOn = nameof(OccurredOn);
        public static readonly string MessageID = nameof(MessageID);
        public static readonly string CorrelationID = nameof(CorrelationID);
        public static readonly string CausationID = nameof(CausationID);
        public static readonly string ClientID = nameof(ClientID);
        public static readonly string UserID = nameof(UserID);
        public static readonly string Origin = nameof(Origin);
    }
}
