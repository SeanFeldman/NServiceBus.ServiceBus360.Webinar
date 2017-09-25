using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

public class CreateUserHandler :IHandleMessages<CreateUser>
{
    public async Task Handle(CreateUser message, IMessageHandlerContext context)
    {
        log.Info("creating user... working hard...");
        await Task.Delay(2000);
        //        throw new Exception("Kaboom Rico!");
        log.Info($"Created user with ID: {message.UserId}");

        await context.Publish(new UserCreated { UserId = message.UserId });
    }

    static ILog log = LogManager.GetLogger<CreateUserHandler>();
}