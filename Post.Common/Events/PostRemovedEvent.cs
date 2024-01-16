using CQRS.Core.Events;

namespace Post.Common.Events;

public record PostRemovedEvent(Guid Id,
    long Version) : BaseEvent(Id, nameof(PostRemovedEvent), Version);