using CQRS.Core.Commands;
using CQRS.Core.Messages;

namespace Post.Cmd.Api.Commands;

public record EditMessageCommand(Guid Id, string Message) : BaseCommand(Id);