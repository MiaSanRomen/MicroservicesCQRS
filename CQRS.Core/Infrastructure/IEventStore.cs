using CQRS.Core.Events;

namespace CQRS.Core.Infrastructure;

public interface IEventStore
{
    Task SaveEventAsync(Guid aggregateId, IEnumerable<BaseEvent> events, long expectedVersion);
    Task<List<BaseEvent>> GetEventsAsync(Guid aggregateId);
}