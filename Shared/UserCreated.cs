using NServiceBus;

public class UserCreated : IEvent
{
    public string UserId { get; set; }
}