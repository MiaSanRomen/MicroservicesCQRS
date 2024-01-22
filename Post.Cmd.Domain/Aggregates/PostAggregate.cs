using CQRS.Core.Domain;
using Post.Common.Events;
// ReSharper disable SuggestBaseTypeForParameter
// ReSharper disable ArrangeObjectCreationWhenTypeNotEvident

namespace Post.Cmd.Domain.Aggregates;

public sealed class PostAggregate : AggregateRoot
{
    public readonly Dictionary<Guid, Tuple<string, string>> Comments = new();
    
    public string Author;

    public bool IsActive { get; set; }
    
    //sourcing handler
    public PostAggregate()
    {
        
    }

    public PostAggregate(string author, string message)
    {
        RaiseEvent(new PostCreatedEvent(author, message, DateTime.Now));
    }

    public void EditMessage(string message)
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot edit the message of inactive post!");
        
        if (!string.IsNullOrWhiteSpace(message))
            throw new InvalidOperationException("Message cannot be null or empty!");
        
        RaiseEvent(new MessageUpdatedEvent(message));
    }

    public void LikePost()
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot like inactive post!");
        
        RaiseEvent(new PostLikedEvent());
    }

    public void AddComment(string comment, string username)
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot edit inactive post!");
        
        if (!string.IsNullOrWhiteSpace(comment))
            throw new InvalidOperationException("Comment cannot be null or empty!");
        
        RaiseEvent(new CommentAddedEvent(Guid.NewGuid(), username, comment, DateTime.Now));
    }

    public void EditComment(Guid commentId, string comment, string username)
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot edit inactive post!");
        
        if (!string.IsNullOrWhiteSpace(comment))
            throw new InvalidOperationException("Comment cannot be null or empty!");
        
        if (!username.Equals(Comments[commentId].Item2, StringComparison.CurrentCultureIgnoreCase))
            throw new InvalidOperationException("Cannot edit not your comment!");
        
        RaiseEvent(new CommentUpdatedEvent(commentId, username, comment, DateTime.Now));
    }

    public void RemoveComment(Guid commentId, string username)
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot edit inactive post!");
        
        if (!username.Equals(Comments[commentId].Item2, StringComparison.CurrentCultureIgnoreCase))
            throw new InvalidOperationException("Cannot remove not your comment!");
        
        RaiseEvent(new CommentRemovedEvent(commentId));
    }

    public void RemovePost(string username)
    {
        if (!IsActive)
            throw new InvalidOperationException("Cannot remove inactive post!");
        
        if (!username.Equals(Author, StringComparison.CurrentCultureIgnoreCase))
            throw new InvalidOperationException("Cannot remove not your post!");
        
        RaiseEvent(new PostRemovedEvent());
    }

    public void Apply(PostCreatedEvent @event)
    {
        Id = @event.Id;
        IsActive = true;
        Author = @event.Username;
    }

    public void Apply(MessageUpdatedEvent @event)
    {
        Id = @event.Id;
    }

    public void Apply(PostLikedEvent @event)
    {
        Id = @event.Id;
    }

    public void Apply(CommentAddedEvent @event)
    {
        Id = @event.Id;
        Comments.Add(@event.CommentId, new (@event.Comment, @event.Username));
    }

    public void Apply(CommentUpdatedEvent @event)
    {
        Id = @event.Id;
        Comments[@event.CommentId] = new (@event.Comment, @event.Username);
    }

    public void Apply(CommentRemovedEvent @event)
    {
        Id = @event.Id;
        Comments.Remove(@event.Id);
    }

    public void Apply(PostRemovedEvent @event)
    {
        Id = @event.Id;
        IsActive = false;
    }
}