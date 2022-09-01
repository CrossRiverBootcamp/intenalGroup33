using Measure.Data.Interfaces;
using Measure.Data.Repositories;
using Measure.Services.Interfaces;
using Measure.Services.Services;
using NServiceBus;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseNServiceBus(hostBuilderContext =>
{
    var endpointConfiguration = new EndpointConfiguration("Measure");
    endpointConfiguration.EnableInstallers();
    endpointConfiguration.EnableOutbox();
    endpointConfiguration.SendOnly();
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
    return endpointConfiguration;
});

builder.Services.AddScoped<IMeasureRepository,MeasureRepository>();
builder.Services.AddScoped<IMeasureService, MeasureService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//var host = Host.CreateDefaultBuilder()
//    .UseNServiceBus(context =>
//    {
//        var endpointConfiguration = new EndpointConfiguration("Measure.ASPNETCore.Sender");
//        var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
//        endpointConfiguration.SendOnly();
//        transport.ConnectionString("host=localhost");
//        return endpointConfiguration;
//    })
//    .ConfigureWebHostDefaults(c => c.UseStartup<Program>())
//    .Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
