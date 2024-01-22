using CQRS.Core.Queries;

namespace Post.Query.Api.Queries;

public sealed class FindPostsWithLikesQuery : BaseQuery
{
    public int NumberOfLikes { get; set; }
}