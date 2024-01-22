using CQRS.Core.Events;

namespace Post.Common.Events;

public record PostCreatedEvent(
    string Username,
    string Message,
    DateTime DatePosted) : BaseEvent(nameof(PostCreatedEvent));