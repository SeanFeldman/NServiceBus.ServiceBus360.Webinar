using System;
using System.Threading.Tasks;
using NServiceBus;

class Program
{
    static async Task Main()
    {
        Console.Title = "Demo.CustomerRelations";

        var endpointConfiguration = new EndpointConfiguration("Demo.CustomerRelations");
        ConfigureEndpoint.With(endpointConfiguration);

        var endpointInstance = await Endpoint.Start(endpointConfiguration)
            .ConfigureAwait(false);

        Console.Clear();
        Console.WriteLine("Press any key to exit");
        Console.WriteLine("---------------------");
        Console.ReadKey();

        await endpointInstance.Stop()
            .ConfigureAwait(false);
    }
}