using CQRS.Core.Commands;
using CQRS.Core.Messages;

namespace Post.Cmd.Api.Commands;

public record LikePostCommand(Guid Id, string Message) : BaseCommand(Id);