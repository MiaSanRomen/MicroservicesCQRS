using CQRS.Core.Events;

namespace Post.Common.Events;

public record CommentAddedEvent(Guid Id,
    long Version,
    Guid CommentId,
    string Username,
    string Comment,
    DateTime CommentDate) : BaseEvent(Id, nameof(CommentAddedEvent), Version);