using CQRS.Core.Commands;
using CQRS.Core.Messages;

namespace Post.Cmd.Api.Commands;

public record EditCommentCommand(Guid Id, Guid CommentId, string Username, string Comment) : BaseCommand(Id);