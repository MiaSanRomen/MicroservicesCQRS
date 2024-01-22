using CQRS.Core.Queries;

namespace Post.Query.Api.Queries;

public sealed class FindPostByIdQuery : BaseQuery
{
    public Guid Id { get; set; }
}