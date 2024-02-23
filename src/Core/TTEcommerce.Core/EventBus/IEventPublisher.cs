namespace TTEcommerce.Core.EventBus;

public interface IEventPublisher
{
    Task PublishEventAsync(INotification @event, CancellationToken cancellationToken);
    Task PublishEventsAsync(IEnumerable<INotification> @events, CancellationToken cancellationToken);
}
