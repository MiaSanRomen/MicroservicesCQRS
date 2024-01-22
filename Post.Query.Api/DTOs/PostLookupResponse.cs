using Post.Common.DTOs;
using Post.Query.Domain.Entities;

namespace Post.Query.Api.DTOs
{
    public sealed record PostLookupResponse(string Message) : BaseResponse(Message)
    {
        public List<PostEntity> Posts { get; set; }
    }
}