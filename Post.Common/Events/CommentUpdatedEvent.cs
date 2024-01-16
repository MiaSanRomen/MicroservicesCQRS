using CQRS.Core.Events;

namespace Post.Common.Events;

public record CommentUpdatedEvent(Guid Id,
    long Version,
    Guid CommentId,
    string Username,
    string Comment,
    DateTime EditDate) : BaseEvent(Id, nameof(CommentUpdatedEvent), Version);