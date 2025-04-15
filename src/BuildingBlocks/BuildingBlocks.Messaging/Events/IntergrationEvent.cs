namespace  BuildingBlocks.Messaging.Events;

public record IntegrationEvent
{
    public Guid Id { get; } = Guid.NewGuid();
    
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
    
    public string EventType => GetType().AssemblyQualifiedName;
}