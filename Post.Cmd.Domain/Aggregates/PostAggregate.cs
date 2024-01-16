using CQRS.Core.Domain;
using Post.Common.Events;
// ReSharper disable SuggestBaseTypeForParameter
// ReSharper disable ArrangeObjectCreationWhenTypeNotEvident

namespace Post.Cmd.Domain.Aggregates;

public sealed class PostAggregate : AggregateRoot
{
    private readonly Dictionary<Guid, Tuple<string, string>> _comments = new();
    
    private string _author;

    public bool IsActive { get; private set; }

    public PostAggregate(Guid id, string author, string message)
    {
        RaiseEvent(new PostCreatedEvent(id, 0, author, message, DateTime.Now));
    }

    public void EditMessage(string message)
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot edit the message of inactive post!");
        
        if (!string.IsNullOrWhiteSpace(message))
            throw new InvalidOperationException("Message cannot be null or empty!");
        
        RaiseEvent(new MessageUpdatedEvent(Id, 0, message));
    }

    public void LikePost()
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot like inactive post!");
        
        RaiseEvent(new PostLikedEvent(Id, 0));
    }

    public void AddComment(string comment, string username)
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot edit inactive post!");
        
        if (!string.IsNullOrWhiteSpace(comment))
            throw new InvalidOperationException("Comment cannot be null or empty!");
        
        RaiseEvent(new CommentAddedEvent(Id, 0, Guid.NewGuid(), username, comment, DateTime.Now));
    }

    public void EditComment(Guid commentId, string comment, string username)
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot edit inactive post!");
        
        if (!string.IsNullOrWhiteSpace(comment))
            throw new InvalidOperationException("Comment cannot be null or empty!");
        
        if (!username.Equals(_comments[commentId].Item2, StringComparison.CurrentCultureIgnoreCase))
            throw new InvalidOperationException("Cannot edit not your comment!");
        
        RaiseEvent(new CommentUpdatedEvent(Id, 0, commentId, username, comment, DateTime.Now));
    }

    public void RemoveComment(Guid commentId, string username)
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot edit inactive post!");
        
        if (!username.Equals(_comments[commentId].Item2, StringComparison.CurrentCultureIgnoreCase))
            throw new InvalidOperationException("Cannot remove not your comment!");
        
        RaiseEvent(new CommentRemovedEvent(Id, 0, commentId));
    }

    public void RemovePost(string username)
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot remove inactive post!");
        
        if (!username.Equals(_author, StringComparison.CurrentCultureIgnoreCase))
            throw new InvalidOperationException("Cannot remove not your post!");
        
        RaiseEvent(new PostRemovedEvent(Id, 0));
    }

    private void Apply(PostCreatedEvent @event)
    {
        Id = @event.Id;
        IsActive = true;
        _author = @event.Username;
    }

    private void Apply(MessageUpdatedEvent @event)
    {
        Id = @event.Id;
    }

    private void Apply(PostLikedEvent @event)
    {
        Id = @event.Id;
    }

    private void Apply(CommentAddedEvent @event)
    {
        Id = @event.Id;
        _comments.Add(@event.CommentId, new (@event.Comment, @event.Username));
    }

    private void Apply(CommentUpdatedEvent @event)
    {
        Id = @event.Id;
        _comments[@event.CommentId] = new (@event.Comment, @event.Username);
    }

    private void Apply(CommentRemovedEvent @event)
    {
        Id = @event.Id;
        _comments.Remove(@event.Id);
    }

    private void Apply(PostRemovedEvent @event)
    {
        Id = @event.Id;
        IsActive = false;
    }
}