﻿using CQRS.Core.Events;

namespace Post.Common.Events;

public record PostRemovedEvent() : BaseEvent(nameof(PostRemovedEvent));