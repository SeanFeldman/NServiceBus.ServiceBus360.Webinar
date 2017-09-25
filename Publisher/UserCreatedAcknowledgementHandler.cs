using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

public class UserCreatedAcknowledgementHandler : IHandleMessages<UserCreated>
{
    public Task Handle(UserCreated message, IMessageHandlerContext context)
    {
        log.Info($"User with ID {message.UserId} was created. Great success!");
        return Task.CompletedTask;
    }

    private static ILog log = LogManager.GetLogger<UserCreatedAcknowledgementHandler>();
}
