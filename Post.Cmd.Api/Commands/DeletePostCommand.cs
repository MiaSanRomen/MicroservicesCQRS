using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands;

public record DeletePostCommand(Guid Id, string Username) : BaseCommand(Id);