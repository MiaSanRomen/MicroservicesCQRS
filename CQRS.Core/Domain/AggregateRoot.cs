﻿using System.Reflection;
using CQRS.Core.Events;

namespace CQRS.Core.Domain;

public abstract class AggregateRoot
{
    private readonly List<BaseEvent> _changes = new();
    
    public Guid Id { get; protected set; }
    public long Version { get; set; } = -1;

    public IEnumerable<BaseEvent> GetUncommittedChanges()
    {
        return _changes;
    }
    
    public void MarkChangesAsCommitted()
    {
        _changes.Clear();
    }

    public void ReplayEvents(IEnumerable<BaseEvent> events)
    {
        foreach (var @event in events)
        {
            ApplyChange(@event, false);
        }
    }

    protected void RaiseEvent(BaseEvent @event)
    {
        ApplyChange(@event, true);
    }
    
    private void ApplyChange(BaseEvent @event, bool isNew)
    {
        var method = GetType().GetMethod("Apply", new [] { @event.GetType() });
        if (method is null)
            throw new ArgumentNullException(nameof(method),
                $"The apply method was not found in aggregate for event {@event.GetType().Name}");

        method.Invoke(this, new object?[] { @event });
        if(isNew)
            _changes.Add(@event);
    }
    
}