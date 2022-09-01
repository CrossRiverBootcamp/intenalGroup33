using NServiceBus;
using System.Data.SqlClient;

class Program
{
    public static async Task Main()
    {
        Console.Title="Subscriber.NSB";
        var endpointConfiguration = new EndpointConfiguration("Subscriber.NSB");
        var persistence = endpointConfiguration.UsePersistence<SqlPersistence>();
        persistence.ConnectionBuilder(
        connectionBuilder: () =>
        {
            return new SqlConnection(@"Data Source=.;Initial Catalog=Weight;Integrated Security=True");
        });
        var dialect = persistence.SqlDialect<SqlDialect.MsSqlServer>();
        dialect.Schema("dbo");
        var transport = endpointConfiguration.UseTransport<RabbitMQTransport
            >();
        transport.ConnectionString("host=localhost");
        transport.UseConventionalRoutingTopology(QueueType.Quorum);
        endpointConfiguration.EnableInstallers();
        endpointConfiguration.EnableOutbox();

        var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false); ;
        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();

        await endpointInstance.Stop().ConfigureAwait(false); ;
    }
}

