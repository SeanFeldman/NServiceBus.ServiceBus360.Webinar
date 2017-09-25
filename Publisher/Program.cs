using System;
using System.Threading.Tasks;
using NServiceBus;

class Program
{
    static async Task Main()
    {
        Console.Title = "Demo.Registration";

        var endpointConfiguration = new EndpointConfiguration("Demo.Registration");
        ConfigureEndpoint.With(endpointConfiguration);

        var endpointInstance = await Endpoint.Start(endpointConfiguration)
            .ConfigureAwait(false);

        Console.Clear();
        Console.WriteLine("Press 'enter' to send a message");
        Console.WriteLine("Press any other key to exit");
        Console.WriteLine("-------------------------------");

        while (true)
        {
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key != ConsoleKey.Enter)
            {
                break;
            }

            var command = new CreateUser
            {
                UserId = Guid.NewGuid().ToString()
            };
            await endpointInstance.Send(command)
                .ConfigureAwait(false);
            Console.WriteLine($"Request to create a user {command.UserId} sent.");
        }
        await endpointInstance.Stop()
                .ConfigureAwait(false);
    }
}