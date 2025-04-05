using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container


builder.Services
    .AddApplicationServices()
    .AddInfrastructureServiceCollection(builder.Configuration);


var app = builder.Build();

//Configure the HTTP request pipeline.

app.MapGet("/", () => "Hello World!");

app.Run();