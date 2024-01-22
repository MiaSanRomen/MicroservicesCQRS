namespace CQRS.Core.Messages;

public abstract record BaseMessage()
{
    public Guid Id { get; set; }
};