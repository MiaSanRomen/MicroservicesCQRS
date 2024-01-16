using CQRS.Core.Events;

namespace Post.Common.Events;

public record MessageUpdatedEvent(Guid Id,
    long Version,
    string Message) : BaseEvent(Id, nameof(MessageUpdatedEvent), Version);