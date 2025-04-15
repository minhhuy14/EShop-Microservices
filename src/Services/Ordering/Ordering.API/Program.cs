using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
//-----------------
//Infrastructure - EFCore
//Application - MediatR
//API - Carter, HealthChecks, Swagger

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServiceCollection(builder.Configuration)
    .AddApiServices(builder.Configuration);



var app = builder.Build();

//Configure the HTTP request pipeline.

app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
}

app.MapGet("/", () => "Hello World!");

app.Run();