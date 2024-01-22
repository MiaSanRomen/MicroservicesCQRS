using CQRS.Core.Events;

namespace Post.Common.Events;

public record CommentAddedEvent(
    Guid CommentId,
    string Username,
    string Comment,
    DateTime CommentDate) : BaseEvent(nameof(CommentAddedEvent));