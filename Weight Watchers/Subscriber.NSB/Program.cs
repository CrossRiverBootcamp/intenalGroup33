using NServiceBus;
class Program
{
    public async Task Main()
    {
        Console.Title="Subscriber.NSB";
        var endpointConfiguration = new EndpointConfiguration("Subscriber.NSB");
        endpointConfiguration.UsePersistence<SqlPersistence>();
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.EnableOutbox();
        var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
        transport.UseConventionalRoutingTopology(QueueType.Quorum);
        transport.ConnectionString("host=localhost");


        var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false); ;
        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();

        await endpointInstance.Stop().ConfigureAwait(false); ;
    }
}

