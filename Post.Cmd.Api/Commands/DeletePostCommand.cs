using CQRS.Core.Commands;
using CQRS.Core.Messages;

namespace Post.Cmd.Api.Commands;

public record DeletePostCommand(Guid Id, string Username) : BaseCommand(Id);