namespace TTEcommerce.Core.Testing;

public record class DummyCommand(DummyAggregateId Id) : ICommand {}
