using CQRS.Core.Events;

namespace Post.Common.Events;

public record CommentRemovedEvent(Guid Id,
    long Version,
    Guid CommentId) : BaseEvent(Id, nameof(CommentRemovedEvent), Version);