using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands;

public record RemoveCommentCommand(Guid Id, Guid CommentId, string Username) : BaseCommand(Id);