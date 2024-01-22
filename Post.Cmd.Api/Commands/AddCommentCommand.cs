using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands;

public record AddCommentCommand(Guid Id, string Username, string Comment) : BaseCommand(Id);