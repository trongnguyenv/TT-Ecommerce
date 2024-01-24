namespace TTEcommerce.Core.CQRS.QueryHandling;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
