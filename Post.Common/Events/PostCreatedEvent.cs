using CQRS.Core.Events;

namespace Post.Common.Events;

public record PostCreatedEvent(Guid Id,
    long Version,
    string Username,
    string Message,
    DateTime DatePosted) : BaseEvent(Id, nameof(PostCreatedEvent), Version);