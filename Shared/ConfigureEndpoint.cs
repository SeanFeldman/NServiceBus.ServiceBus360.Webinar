using System;
using NServiceBus;
using NServiceBus.Configuration.AdvanceExtensibility;
using NServiceBus.Transport.AzureServiceBus;

public static class ConfigureEndpoint
{
    public static void With(EndpointConfiguration endpointConfiguration)
    {
        endpointConfiguration.SendFailedMessagesTo("error");
        endpointConfiguration.AuditProcessedMessagesTo("audit");
        var transport = endpointConfiguration.UseTransport<AzureServiceBusTransport>();
        if (string.IsNullOrWhiteSpace(ConnectionStrings.AzureServiceBus))
        {
            throw new Exception("'AzureServiceBus.ConnectionString' is required for the demo to run.");
        }
        transport.ConnectionString(ConnectionStrings.AzureServiceBus);
        transport.UseForwardingTopology();
        transport.BrokeredMessageBodyType(SupportedBrokeredMessageBodyTypes.ByteArray);

        endpointConfiguration.UsePersistence<InMemoryPersistence>();
        endpointConfiguration.UseSerialization<JsonSerializer>();
        endpointConfiguration.EnableInstallers();
        var recoverability = endpointConfiguration.Recoverability();
        recoverability.DisableLegacyRetriesSatellite();

        if (endpointConfiguration.GetSettings().GetOrDefault<string>("NServiceBus.Routing.EndpointName") == "Demo.Registration")
        {
            transport.Routing().RouteToEndpoint(typeof(CreateUser), "Demo.Backend");
        }
    }
}