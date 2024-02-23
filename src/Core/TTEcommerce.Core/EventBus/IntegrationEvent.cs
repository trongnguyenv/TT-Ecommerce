namespace TTEcommerce.Core.EventBus;

public class IntegrationEvent : IIntegrationEvent
{
    public IntegrationEvent() { }

    private IntegrationEvent(INotification @event)
    {
        EventName = @event.GetType().Name;
        JSON_Payload = JsonConvert.SerializeObject(@event);
    }

    public string EventName { get; } // Event name identifier
    public string JSON_Payload { get; } // Serialized data
    public Guid Id { get; set; } = Guid.NewGuid();

    public static IntegrationEvent FromNotification(
        INotification domainEvent)
    {
        return new IntegrationEvent(domainEvent);
    }
}
