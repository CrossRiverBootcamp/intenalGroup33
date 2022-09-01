using Microsoft.EntityFrameworkCore;
using Subscriber.Data.Data;
using Subscriber.Data.Entities;
using Subscriber.Data.Interfaces;
using Subscriber.Services.Interfaces;
using Subscriber.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISubscriberService, SubscriberService>();
builder.Services.AddScoped<ISubscriberData, SubscriberData>();
builder.Services.AddDbContextFactory<WeightDBContext>(item =>
    item.UseSqlServer(builder.Configuration.GetConnectionString("myconn")));

builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>
{
    options.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
});
app.UseHttpsRedirection();

//app.ConfigureCustomExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
