using CQRS.Core.Messages;

namespace CQRS.Core.Events;

public abstract record BaseEvent(Guid Id, string Type, long Version) : BaseMessage(Id)
{
    
}