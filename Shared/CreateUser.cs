using NServiceBus;

public class CreateUser : ICommand
{
    public string UserId { get; set; }
}