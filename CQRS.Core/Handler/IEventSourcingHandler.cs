using CQRS.Core.Domain;

namespace CQRS.Core.Handler;

public interface IEventSourcingHandler<T> where T : AggregateRoot
{
    Task SaveAsync(AggregateRoot aggregateRoot);
    Task<T> GetByIdAsync(Guid aggregateId);
}