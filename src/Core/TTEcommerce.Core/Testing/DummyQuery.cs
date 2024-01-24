namespace TTEcommerce.Core.Testing;

public record class DummyQuery(DummyAggregateId Id) : IQuery<DummyAggregateRoot> {}
