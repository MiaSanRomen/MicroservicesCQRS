using CQRS.Core.Commands;

namespace Post.Cmd.Api.Commands;

public record NewPostCommand(Guid Id, string Username, string Comment) : BaseCommand(Id);