using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

public class UserCreatedHandler : IHandleMessages<UserCreated>
{
    public Task Handle(UserCreated message, IMessageHandlerContext context)
    {
        log.Info($"Sent welcome email to a new uesr with ID: {message.UserId}");
        return Task.CompletedTask;
    }

    private static ILog log = LogManager.GetLogger<UserCreatedHandler>();
}