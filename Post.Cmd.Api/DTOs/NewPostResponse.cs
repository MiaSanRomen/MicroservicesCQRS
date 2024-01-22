using Post.Common.DTOs;

namespace Post.Cmd.Api.DTOs;

public sealed record NewPostResponse(string Message) : BaseResponse(Message)
{
    public Guid Id { get; set; }
};