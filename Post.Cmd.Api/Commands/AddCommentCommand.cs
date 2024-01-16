using CQRS.Core.Commands;
using CQRS.Core.Messages;

namespace Post.Cmd.Api.Commands;

public record AddCommentCommand(Guid Id, string Username, string Comment) : BaseCommand(Id);