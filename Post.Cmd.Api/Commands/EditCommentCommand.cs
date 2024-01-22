using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands;

public record EditCommentCommand(Guid Id, Guid CommentId, string Username, string Comment) : BaseCommand(Id);