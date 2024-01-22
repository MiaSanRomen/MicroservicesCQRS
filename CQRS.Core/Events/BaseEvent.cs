using CQRS.Core.Messages;

namespace CQRS.Core.Events;

public abstract record BaseEvent(string Type) : BaseMessage()
{
    public long Version { get; set; }
}