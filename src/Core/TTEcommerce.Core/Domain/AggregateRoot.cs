using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace TTEcommerce.Core.Domain;

public class AggregateRoot<TKey> : IAggregateRoot<TKey>
    where TKey : StronglyTypedId<Guid>
{
    [JsonIgnore] private readonly Queue<IDomainEvent> _uncommittedEvents = new();

    [Identity]
    public Guid AggregateId
    {
        get => Id.Value;
        set { }
    }

    public TKey Id { get; set; } = default!;

    public long Version { get; protected set; }

    public IEnumerable<IDomainEvent> GetUncommittedEvents()
    {
        return _uncommittedEvents;
    }

    public void ClearUncommittedEvents()
    {
        _uncommittedEvents.Clear();
    }

    protected void AppendEvent(IDomainEvent @event)
    {
        _uncommittedEvents.Enqueue(@event);
    }
}

//https://event-driven.io/en/using_strongly_typed_ids_with_marten/
