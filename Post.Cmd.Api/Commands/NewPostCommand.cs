using CQRS.Core.Commands;
using CQRS.Core.Messages;

namespace Post.Cmd.Api.Commands;

public record NewPostCommand(Guid Id, string Username, string Comment) : BaseCommand(Id);