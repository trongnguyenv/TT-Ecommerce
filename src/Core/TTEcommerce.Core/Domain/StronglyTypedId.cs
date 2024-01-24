using TTEcommerce.Core.Exceptions;

namespace TTEcommerce.Core.Domain;

public abstract class StronglyTypedId<T> : ValueObject<StronglyTypedId<T>>
{
    public StronglyTypedId(T value)
    {
        if (value.Equals(Guid.Empty))
            throw new BusinessRuleException("A valid id must be provided.");

        Value = value;
    }

    public T Value { get; }

    public override int GetHashCode()
    {
        return EqualityComparer<T>.Default.GetHashCode(Value);
    }

    public static bool operator ==(StronglyTypedId<T>? left, StronglyTypedId<T>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(StronglyTypedId<T>? left, StronglyTypedId<T>? right)
    {
        return !Equals(left, right);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}