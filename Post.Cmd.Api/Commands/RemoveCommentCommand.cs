using CQRS.Core.Commands;
using CQRS.Core.Messages;

namespace Post.Cmd.Api.Commands;

public record RemoveCommentCommand(Guid Id, Guid CommentId, string Username) : BaseCommand(Id);