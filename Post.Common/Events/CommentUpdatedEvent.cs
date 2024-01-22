using CQRS.Core.Events;

namespace Post.Common.Events;

public record CommentUpdatedEvent(Guid CommentId,
    string Username,
    string Comment,
    DateTime EditDate) : BaseEvent(nameof(CommentUpdatedEvent));