﻿using CQRS.Core.Events;

namespace Post.Common.Events;

public record PostLikedEvent() : BaseEvent(nameof(PostLikedEvent));