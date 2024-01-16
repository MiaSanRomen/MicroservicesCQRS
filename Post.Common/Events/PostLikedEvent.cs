using CQRS.Core.Events;

namespace Post.Common.Events;

public record PostLikedEvent(Guid Id, long Version) : BaseEvent(Id, nameof(PostLikedEvent), Version);