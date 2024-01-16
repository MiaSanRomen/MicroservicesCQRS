using CQRS.Core.Domain;
using CQRS.Core.Events;
using CQRS.Core.Infrastructure;

namespace Post.Cmd.Infrastructure.Stores;

public sealed class EventStore : IEventStore
{
    private readonly IEventStoreRepository _eventStoreRepository;

    public EventStore(IEventStoreRepository eventStoreRepository)
    {
        _eventStoreRepository = eventStoreRepository;
    }
    
    public async Task SaveEventAsync(Guid aggregateId, IEnumerable<BaseEvent> events, long expectedVersion)
    {
        var eventStream = await _eventStoreRepository.FindByAggregateId(aggregateId);

        if (eventStream is not { Count: > 0 })
            throw new KeyNotFoundException("Incorrect post ID!");

        return eventStream.OrderBy(ev => ev.Version).Select(ev => ev.EventData).ToList();
    }

    public async Task<List<BaseEvent>> GetEventsAsync(Guid aggregateId)
    {
        var eventStream = await _eventStoreRepository.FindByAggregateId(aggregateId);

        if (eventStream is not { Count: > 0 })
            throw new KeyNotFoundException("Incorrect post ID!");

        return eventStream.OrderBy(ev => ev.Version).Select(ev => ev.EventData).ToList();
    }
}